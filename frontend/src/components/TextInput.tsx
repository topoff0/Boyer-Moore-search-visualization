interface TextInputProps {
  label?: string;
  placeholder?: string;
  value: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  className?: string;
}


const TextInput = ({ label, placeholder = "", value, onChange, className }: TextInputProps) => {
  return (
    <div className="flex flex-col w-full max-w-sm">
      {label && (
        <label className="mb-2 text-pink-50 font-mono font-semibold text-xs">
          {label}
        </label>
      )}
      <input
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        className={`
          text-sm
          px-4 py-2
          rounded-lg
          bg-rose-100
          text-pink-800
          placeholder-pink-300
          font-mono
          font-semibold
          focus:outline-none
          focus:ring-2
          focus:ring-rose-400
          focus:ring-offset-1
          transition
          duration-200
          ease-in-out
          shadow-sm
          hover:shadow-md
          ${className}
        `}
      />
    </div>
  )
}

export default TextInput
