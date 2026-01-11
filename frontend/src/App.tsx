import { Routes, Route } from "react-router-dom";
import Main from "./pages/Main";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Routes>
        <Route path="/" element={<Main />} />
      </Routes>
    </QueryClientProvider>
  )
}

export default App
