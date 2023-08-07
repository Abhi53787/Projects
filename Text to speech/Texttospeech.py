import pyttsx3
speech=pyttsx3.init()

text = input("Welcome to text to speech converter Ready let's begin ? yes, Then type start else bye to stop: ")
text = text.lower()
if text=="start"or "yes":
    while text!="bye":
        text = input("Enter a word to convert Text into speech: ")

        text = text.lower()
        speech.setProperty('rate',140)

        speech.say(text)
        speech.runAndWait()
else:
    pass