import type { SearchStep } from "../api/search";

interface Props {
  text: string;
  pattern: string;
  step: SearchStep | null;
  isFound: boolean | null;
  executionTime: string;
}

const CELL_SIZE_REM = 2;

const SearchVisualization = ({ text, pattern, step, isFound, executionTime }: Props) => {

  const patternStart = step ? step.textPointer - step.patternPointer : 0;

  const isInPatternRange = (index: number) =>
    step && index >= patternStart && index < patternStart + pattern.length;

  return (
    <div className="flex flex-col gap-4 font-mono text-xl items-center">

      {/* TEXT */}
      <div className="flex">
        {text.split("").map((char, index) => {
          let className = "w-8 h-8 flex items-center justify-center rounded text-pink-900";

          if (isFound !== null && isInPatternRange(index)) {
            // at the end highlight pattern in text
            className = isFound
              ? "w-8 h-8 flex items-center justify-center rounded bg-green-400 text-white"
              : "w-8 h-8 flex items-center justify-center rounded bg-red-400 text-white";
          } else if (isInPatternRange(index)) {
            // highlight current pattern in text
            const patternCharIndex = index - patternStart;
            const stepMatch = step && patternCharIndex === step.patternPointer && step.isMatch;
            className = stepMatch
              ? "w-8 h-8 flex items-center justify-center rounded bg-green-400 text-white"
              : "w-8 h-8 flex items-center justify-center rounded bg-pink-400 text-white";
          } if (step && step.textPointer === index) {
            // current symbol in text
            className = step.isMatch
              ? "w-8 h-8 flex items-center justify-center rounded bg-green-400 text-white"
              : "w-8 h-8 flex items-center justify-center rounded bg-red-400 text-white";
          }

          return (
            <span key={index} className={className}>
              {char}
            </span>
          );
        })}
      </div>

      {/* PATTERN */}
      <div className="relative h-10 overflow-visible">
        <div
          className="flex absolute transition-transform duration-500 ease-in-out"
          style={{
            transform: `translateX(${patternStart * CELL_SIZE_REM - text.length}rem)`,
          }}
        >
          {pattern.split("").map((char, index) => (
            <span
              key={index}
              className={`w-8 h-8 flex items-center justify-center rounded
                ${step && index === step.patternPointer
                  ? step.isMatch
                    ? "bg-green-400 text-white"
                    : "bg-red-400 text-white"
                  : "text-pink-900"
                }
                ${isFound ? "bg-green-400 text-white" : ""
                }`}
            >
              {char}
            </span>
          ))}
        </div>
      </div>

      {/* DESCRIPTION */}
      {step && (
        <p className="text-sm font-bold text-pink-100 text-center transition-opacity duration-300">
          {step.description}
        </p>
      )}
      <p className="text-sm font-bold text-pink-100 text-center transition-opacity duration-300">
        {`Execution time: ${executionTime}`}
      </p>
      <p className="text-sm font-bold text-pink-100 text-center transition-opacity duration-300">
        {isFound ? `Found : ${isFound ? "True" : "False"}` : ""}
      </p>
    </div>
  );
};

export default SearchVisualization;

