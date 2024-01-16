import React from 'react'
import PostImage from './PostImage';

export async function getData() {
    const res = await fetch(`http://localhost:7002/api/search`);

    if (!res.ok) throw new Error('Failed to fetch data');

    return res.json();
}

export default async function Listings() {
    const data = await getData();
    
    return (
        <div className='w-3'>
            {JSON.stringify(data, null, 2)}
            {/* {data && data.results.map((post: any) => (
                <PostImage imageUrl={post.imageUrl} />
 
            ))} */}
        </div>
    )
}
