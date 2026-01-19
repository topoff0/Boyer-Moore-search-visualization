import { useState } from "react";
import { useMooreSearch } from "../hooks/useMoore";
import SearchVisualization from "../components/SearchVizualization";
import { useStepAnimation } from "../hooks/useStepAnimation";
import TextInput from "../components/TextInput";
import RangeInput from "../components/RangeInput";

const Main = () => {

  const [text, setText] = useState("");
  const [pattern, setPattern] = useState("");

  const { data, isLoading, error } = useMooreSearch(text, pattern)

  const [animationSpeed, setAnimationSpeed] = useState(500);

  const { currentStep, isFinished } = useStepAnimation(data?.steps, animationSpeed);


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
                isFound={isFinished ? data.isFound : null}
                executionTime={data.executionTime}
              />
            </>
          )}

          <div className="container w-full flex items-center justify-center gap-8">
            <TextInput
              label="String for search"
              placeholder="Text example..."
              value={text}
              onChange={(e) => setText(e.target.value)}
            />
            <TextInput
              label="String for search"
              placeholder="Text example..."
              value={pattern}
              onChange={(e) => setPattern(e.target.value)}
            />
          </div>
          <RangeInput
            min={100}
            max={2500}
            value={animationSpeed}
            step={100}
            onChange={(e) => setAnimationSpeed(Number(e.target.value))}
            label={`Delay: ${animationSpeed}(ms)`}
          />
        </div>
      </div>
    </>
  )
}

export default Main
