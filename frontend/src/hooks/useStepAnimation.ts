import { useEffect, useState } from "react";
import type { SearchStep } from "../api/search";

export const useStepAnimation = (steps?: SearchStep[], delay = 600) => {
  const [currentStepIndex, setCurrentStepIndex] = useState(0);

  useEffect(() => {
    if (!steps || steps.length === 0) return;

    setCurrentStepIndex(0);

    const interval = setInterval(() => {
      setCurrentStepIndex((prev) => {
        if (prev >= steps.length - 1) {
          clearInterval(interval);
          return prev;
        }
        return prev + 1;
      });
    }, delay);

    return () => clearInterval(interval);
  }, [steps, delay]);

  const currentStep = steps ? steps[currentStepIndex] : null;
  const isFinished = steps ? currentStepIndex === steps.length - 1 : false;

  return { currentStep, isFinished };
};

