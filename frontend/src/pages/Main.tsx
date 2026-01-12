import { useState } from "react";
import { useMooreSearch } from "../hooks/useMoore";
import Input from "../components/Input";
import SearchVisualization from "../components/SearchVizualization";
import { useStepAnimation } from "../hooks/useStepAnimation";

const Main = () => {

  const [text, setText] = useState("");
  const [pattern, setPattern] = useState("");

  const { data, isLoading, error } = useMooreSearch(text, pattern)

  const { currentStep, isFinished } = useStepAnimation(data?.steps, 2000);

  return (
    <>
      <div className="bg-rose-300 w-screen h-screen flex items-center justify-center">
        <div className="container min-h-screen flex flex-col gap-y-8 items-center justify-start pt-24">

          <h1
            className="text-center text-3xl font-mono font-extrabold text-pink-50 mb-24">
            Boyer Moore Seach vizualization
          </h1>

          {isLoading && <p className="text-xl text-center font-mono font-extrabold text-pink-200">Searching...</p>}
          {error && <p className="text-xl text-center font-mono font-extrabold text-red-400">{error.message}</p>}

          {data && (
            <>
              <SearchVisualization
                text={text}
                pattern={pattern}
                step={currentStep}
                found={isFinished ? data.found : null}
                executionTime={data.executionTime}
              />
            </>
          )}

          <div className="container w-full flex items-center justify-center gap-8">
            <Input
              label="String for search"
              placeholder="Text example..."
              value={text}
              onChange={(e) => setText(e.target.value)}
            />
            <Input
              label="String for search"
              placeholder="Text example..."
              value={pattern}
              onChange={(e) => setPattern(e.target.value)}
            />
          </div>
        </div>
      </div>
    </>
  )
}

export default Main
