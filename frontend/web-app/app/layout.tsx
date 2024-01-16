import type { Metadata } from 'next'
import { Inter } from 'next/font/google'
import './globals.css'
import Navbar from './nav/Navbar'

const inter = Inter({ subsets: ['latin'] })

export const metadata: Metadata = {
  title: 'Create Next App',
  description: 'Generated by create next app',
}

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <Navbar />
        <main className='container mx-auto px-5 pt-10'>
          {children}

          <footer className="bg-white rounded-lg shadow dark:bg-gray-900 m-4">
              <div className="w-full max-w-screen-xl mx-auto p-4 md:py-8">

                  <hr className="my-6 border-gray-200 sm:mx-auto dark:border-gray-700 lg:my-8" />
                  <span className="block text-sm text-gray-500 sm:text-center dark:text-gray-400">© 2023 <a href="https://flowbite.com/" className="hover:underline">Flowbite™</a>. All Rights Reserved.</span>
              </div>
          </footer>
        </main>
      </body>
    </html>
  )
}