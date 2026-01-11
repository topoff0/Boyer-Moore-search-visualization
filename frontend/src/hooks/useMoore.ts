import { fetchMooreSearch, type SearchResult } from "../api/search"
import { useQuery } from "@tanstack/react-query"

export const useMooreSearch = (text: string, pattern: string) => {
  return useQuery<SearchResult, Error>({
    queryKey: ["moore-search", text, pattern],
    queryFn: () =>  fetchMooreSearch(text, pattern),
    enabled: !!text && !!pattern,
    staleTime: 1000 * 60,
  });
}

