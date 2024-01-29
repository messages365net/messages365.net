using PostService.DTOs;
using PostService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>();
        CreateMap<CreatePostDto, Post>();
        CreateMap<PostDto, PostCreated>();

        CreateMap<Message, MessageDto>();
        CreateMap<CreateMessageDto, Message>();
        CreateMap<MessageDto, MessageCreated>();

    }
}
