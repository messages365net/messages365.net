import Link from 'next/link'
import React from 'react'

export default function Navbar() {
  return (
    <header className='
      sticky top-0 z-50 flex justify-between bg-white p-5 items-center text-gray-800 shadow-md
    '>
      <div>messages365</div>
      <div>
        <ul className='flex justify-between'>
          <li className='ml-2'>
            <Link href="/">Home </Link>
          </li>
          <li className='ml-2'>
            <Link href="/posts">Posts</Link>
          </li>
          <li className='ml-2'>
            <Link href="/test">test</Link>
          </li>
        </ul>
      </div>
    </header>
  )
}
