import speech_recognition as sr

import pyttsx3

import datetime as dt

import pywhatkit as pk

import wikipedia as wiki

listener = sr.Recognizer()

speaker=pyttsx3.init()

rate = speaker.getProperty('rate')

print(rate)

speaker.setProperty('rate',150)

def speak(text):

speaker.say( 'im your personal assistent,' + text)

speaker.runAndWait()

def speak_ex(text):

speaker.say('yes boss,' + text)

speaker.runAndWait()

va_name= 'jarvis'

speak_ex('I am Your' + va_name + 'Tell boss')

def take_command():

command=''

try:

with sr.Microphone() as source:

print("listening boss.....")

voice =listener.listen(source)

command = listener.recognize_google(voice)

command=command.lower()

if va_name in command:

command=command.replace(va_name +'','')

print(command)

speak(command)

except:

print("check your microphone")

return command

while True:

user_command=take_command()

if 'close' in user_command:

print("see you again")

speak("see you again")

break

elif 'time' in user_command:

cur_time= dt.datetime.now().strftime("%I:%M %p")

print(cur_time)

speak(cur_time)

elif 'play' in user_command:

user_command= user_command.replace('play ','')

print('playing ' +user_command)

speak('playing ' +user_command + 'enjoy boss')

pk.playonyt(user_command)

break

elif 'search for' in user_command or 'google' in user_command:

user_command= user_command.replace('search for','')

user_command= user_command.replace('google','')

speak('Searching for'+ user_command)

pk.search(user_command)

elif 'who is ' in user_command:

user_command= user_command.replace('who is ', '')

info= wiki.summary(user_command,2)

print(info)

speak(info)

else:

speak_ex("please say it again boss")

