interface RangeInputProps {
  min: number;
  max: number;
  step: number;
  value: number;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  label?: string;
  className?: string;
}

const RangeInput = ({ min, max, step, value, onChange, label, className }: RangeInputProps) => {
  return (
    <div className="flex flex-col gap-2 w-80 font-mono">
      <label className="text-center text-pink-50 font-semibold">{label}</label>
      <input
        type="range"
        min={min}
        max={max}
        value={value}
        step={step}
        onChange={onChange}
        className={`
          w-full
          h-2
          bg-pink-50
          rounded-4xl
          appearance-none
          cursor-pointer
          accent-pink-500
          ${className ?? ""}
        `}
      />
    </div>
  )
}

export default RangeInput
