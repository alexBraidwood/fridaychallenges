import Data.Char

verifyPhoneNumber :: String -> Bool
verifyPhoneNumber number =
    length number >= 7 && any isNumber number && any isPunctuation number && any isSpace number

main :: IO ()
main = do
  putStrLn "Hello, please enter a phone number:\n"
  inpStr <- getLine
  if verifyPhoneNumber inpStr
  then putStrLn "Thank you!"
  else putStrLn "That's not a phone number!"
  
