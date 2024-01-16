using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostService.Data;
using PostService.DTOs;
using PostService.Entities;

namespace PostService.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public PostsController(DataContext context, IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetAllPosts(string date)
        {
            var query = _context.Posts.OrderBy(x => x.CreatedAt).AsQueryable();

            if (!string.IsNullOrEmpty(date))
            {
                query = query.Where(x => x.CreatedAt.CompareTo(DateTime.Parse(date).ToUniversalTime()) > 0);
            }

            return await query.ProjectTo<PostDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostById(Guid id)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (post == null) return NotFound();

            return _mapper.Map<PostDto>(post);
        }
        
        // [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePost(CreatePostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            
            post.Author = User.Identity.Name;

            _context.Posts.Add(post);

            var newPost = _mapper.Map<PostDto>(post);

            await _publishEndpoint.Publish(_mapper.Map<PostCreated>(newPost));

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not save changes to the DB");

            return CreatedAtAction(nameof(GetPostById), 
                new {post.Id}, _mapper.Map<PostDto>(post));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);

            if (post == null) return NotFound();

            _context.Posts.Remove(post);

            await _publishEndpoint.Publish<PostDeleted>(new { Id = post.Id.ToString() });

            var result = await _context.SaveChangesAsync() > 0;

            if (!result) return BadRequest("Could not update DB");

            return Ok();
        }
    }
}