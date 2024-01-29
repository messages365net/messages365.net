import React from 'react'
import Listings from './Listings'

export default function page() {
  return (
    <div className='grid grid-cols-4 gap-4'>

      <div>
        <div className='col-span-1 sticky top-28'>
        <div className='col-span-1 sticky top-28'>
            <div className=''>Lorem ipsum dolor sit amet consectetur adipisicing elit. Temporibus sit eius inventore esse, quae mollitia, voluptate rerum saepe eaque ipsa architecto. Ipsam voluptatum fuga magni quisquam. Laudantium corporis quam non?</div>
        </div>
        </div>
      </div>
      
      <div className='col-span-2 mx-auto mt-6'>
        <Listings />
      </div>       
  
      <div>
        <div className='col-span-1 sticky top-28'>
            <div className=''>Lorem ipsum dolor sit amet consectetur adipisicing elit. Temporibus sit eius inventore esse, quae mollitia, voluptate rerum saepe eaque ipsa architecto. Ipsam voluptatum fuga magni quisquam. Laudantium corporis quam non?</div>
        </div>
      </div>
    </div>
  )
}
