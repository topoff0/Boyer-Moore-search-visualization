import axios from "axios";

export interface SearchStep {
  stepNumber: number;
  textPointer: number;
  patternPointer: number;
  description: string;
  isMatch: boolean;
}

export interface SearchResult {
  found: boolean;
  position: number;
  executionTime: string;
  steps: SearchStep[];
}

export const fetchMooreSearch = async (text: string, pattern: string): Promise<SearchResult> => {
  const { data } = await axios.post<SearchResult>("http://localhost:8080/api/moore/execute",
    {
      text, pattern
    },
  );
  console.log(data);
  return data;
}
