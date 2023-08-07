import random
print("Here i'm there to give you string password🙃 ")
fname=input("Enter a name or place or anything that to generate password ")
fname=fname.capitalize()
mname=input("Enter your favourite person name ").lower()
lname=fname+mname
num=int(input("Enter your favourite number or year "))



special=['!','@','#','$','%','^','&','*']
random_number = random.randint(0, 7)
computer_pick = special[random_number]


box=[lname,num,computer_pick]

random_string=random.randint(0,2)
final_pick=box[random_string]
if final_pick==computer_pick:
    print("Your generated password is "+computer_pick+lname+str(num))
elif final_pick==lname:
    print("Your generated password is "+lname+str(num)+computer_pick)
else:
    print("Your generated password is "+str(num)+lname+computer_pick)

