#Tree

A c# (1-n) tree implementation.
This lib was designed to respond to a specific need and can be more generic/reusable, no efforts has been made on that way. For now, the code is left as this.

[![license](https://img.shields.io/github/license/mashape/apistatus.svg?maxAge=2592000)](https://github.com/ApiO/Tree/blob/master/LICENSE)

| Build server                | Platform     | Status                                                                                                                    |
|-----------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status](https://ci.appveyor.com/api/projects/status/o1veopcf7g5syuy2/branch/master?svg=true)](https://ci.appveyor.com/project/ApiO/tree/branch/master)      |
| Travis                      | Linux | [![Build Status](https://travis-ci.org/ApiO/Tree.svg?branch=master)](https://travis-ci.org/ApiO/Tree) |

[Nuget package](https://www.nuget.org/packages/Tree/)

##Project

- Compatibility: .NET 4.5
- Solution VS 2015


##Design constraint

This implementation assume that each nodes has an unique identifier (long). The ids are not set by the tree, you must define them.
To populate this tree you have use the *addChild()* function.


##Features

- Use Template for data
- Browse nodes by id (not index)
- Browse nodes with iterator
- Node depth
- Roots
- Leaves


##License

MIT License

Copyright (c) 2016 

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
