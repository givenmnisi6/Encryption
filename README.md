# Encryption

## More about the Project
In cryptography, encryption is the process of encoding (convert into a coded form) information. This technique transforms the information's initial plaintext representation into an alternate version known as ciphertext. In an ideal world, only people with the proper credentials may convert ciphertext to plaintext and access the original data. 
## Manual for the Project
- You can download the project from GitHub.
- Open it and change the Connection String to yours in the Form1.cs so that you can be able to register so your credentials can be stored in the database.

<img src="/Images/ConnectionString.PNG" alt="String">

- Before you can encrypt or decrypt you have to enter your credentials.

## Loggin In

<img src="/Images/1.png" alt="LogIn">

## Encrypting & Decrypting a string

<img src="/Images/2.png" alt="Text">

## Encrypting & Decrypting an Image

<img src="/Images/3.png" alt="Text">

- ### Select the photo (note: png)

<img src="/Images/4.png" alt="Text">

- ###  Rename the new encrypted photo

<img src="/Images/5.png" alt="Text">

<img src="/Images/6.png" alt="Text">

- ### Rename the new decrypted photo, it should also be png.

<img src="/Images/7.png" alt="Text">

<img src="/Images/9.png" alt="Text">

- ### NOTE - The process for encrypting a picture is the same as the one for encrypting a RAR file.

## Phase 1 - Password Hash
To make the hash function public to all forms, we are developed a class. The hash password returns a string. We added the header "using System.Security.Cryptography" to allow users to access various cryptographic features. To generate the hash value of 20-byte, we utilized the Cryptography formatted hash function known as the SHA (Secure Hash Algorithm) algorithm. We used a byte array to store our ASCII formatted password. On the completion of our password hash class and method we parsed it to the textboxes which deliver data/password hashes to the database.

## Phase 2 - Self-created Algorithm - Encrypt & Decrypt
The algorithm uses 3 steps:
1. Swap the first letter in the string with the last letter.
      | Original      | New             |
      | :------------ |:---------------:|
      | James         | sameJ           |
      | Hello world   | dello worlH     |
2. Reverse then new string created in step 1 
      | Original      | New             |
      | :------------ |:---------------:|
      | sameJ         | Jemas           |
      | dello worlH   | Hlrow olled     |

3. Take the reversed string from step 2 and moves each character in the string 3 spaces up on the 
ASCII table.
      | Original      | New             |
      | :------------ |:---------------:|
      | Jemas         | Mhpdv           |
      | Hlrow olled   | Kourz#roohg     |
      
- The algorithm is reversed to decode the text; thus step 3 of the encryption process becomes step 1 of the decryption process. 

