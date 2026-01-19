# Boyer-Moore-search-visualization
Visualization of the Boyer-Moore algorithm, one of the most effective algorithms for finding a substring in text. The project allows you to visually study the operation of the algorithm step by step.

## Tech stack
- **backend:** .NET 10(C#) with controllers
- **frontend:** React 19 + Vite + tailwind CSS 4

## 🚀 Quick Start

### Requirements
1. [.NET 10](https://dotnet.microsoft.com/ru-ru/download/dotnet/10.0) 
2. [pnpm 10.27.0+](https://pnpm.io/installation)  

### (TEMPERARY START)
```
#backend
git clone https://github.com/topoff0/Boyer-Moore-search-visualization
cd Boyer-Moore-search-vizualization/backend
docker build -t moore-api .
docker run --rm -d -p 8080:8080 --name moore moore-api

#frontend
cd ../frontend
pnpm i
pnpm vite
```

Now you can open `localhost:5173`.

