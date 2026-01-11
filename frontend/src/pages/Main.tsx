import { useEffect, useState } from "react";
import Input from "../components/Input";
import { useMooreSearch } from "../hooks/useMoore";

const Main = () => {

  const [text, setText] = useState("");
  const [pattern, setPattern] = useState("");

  const { data, isLoading, error } = useMooreSearch(text, pattern)

  // useEffect(() => {
  //   if (data) {
  //     console.log("Moore result:", data);
  //   }
  // }, [data]);

  return (
    <>
      <div className="bg-rose-300 w-screen h-screen flex items-center justify-center">
        <div className="container min-h-screen flex flex-col gap-y-8 items-center justify-start pt-24">
          <h1 className="text-center text-3xl font-mono font-extrabold text-pink-50 mb-24">Booyer Moore Seach vizualization</h1>
          {isLoading && <p>Searching...</p>}
          {error && <p className="text-red-400">{error.message}</p>}

          {data && (
            <>
              <p className="text-2xl text-center font-mono font-extrabold text-pink-50 mb-24">
                {`Found: ${data.found ? "yes" : "no"}`}
              </p>

              <p className="text-2xl text-center font-mono font-extrabold text-pink-50 mb-24">
                {`Execution time: ${data.executionTime}`}
              </p>
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
