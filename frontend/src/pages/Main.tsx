import { useState } from "react";
import Input from "../components/Input";

const Main = () => {

  const [result, setResult] = useState("Some text");
  const [searchString, setSearchString] = useState(""); 
  const [foundString, setFoundString] = useState("");

  return (
    <>
      <div className="bg-rose-300 w-screen h-screen flex items-center justify-center">
        <div className="container min-h-screen flex flex-col gap-y-8 items-center justify-center">
            <h1 className="text-center text-3xl font-mono font-extrabold text-pink-50">Booyer Moore Seach vizualization</h1> 
            <p className="text-2xl text-center font-mono font-extrabold text-pink-50">{result}</p>
            <div className="container w-full flex items-center gap-8">
              <Input 
              label = "String for search"
              placeholder = "Text example..."
              value = {searchString}
              onChange={(e) => setSearchString(e.target.value)}
              />
              <Input
              label = "String for search"
              placeholder = "Text example..."
              value = {foundString}
              onChange={(e) => setFoundString(e.target.value)}
              />
            </div>
        </div>
      </div>
    </>
  )
}

export default Main
