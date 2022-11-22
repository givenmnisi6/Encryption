# Encryption

## More about the Project
In cryptography, encryption is the process of encoding (convert into a coded form) information. This technique transforms the information's initial plaintext representation into an alternate version known as ciphertext. In an ideal world, only people with the proper credentials may convert ciphertext to plaintext and access the original data. 
## Manual for the Project
- You can download the project from GitHub.
- Open it and change the Connection String to yours in the Form1.cs so that you can be able to register so your credentials can be stored in the database.
- Before you can encrypt or decrypt you have to enter your credentials.

## Phase 1 - Password Hash
To make the hash function public to all forms, we are developed a class. The hash password returns a string. We added the header "using System.Security.Cryptography" to allow users to access various cryptographic features. To generate the hash value of 20-byte, we utilized the Cryptography formatted hash function known as the SHA (Secure Hash Algorithm) algorithm. We used a byte array to store our ASCII formatted password. On the completion of our password hash class and method we parsed it to the textboxes which deliver data/password hashes to the database.


Encryption algorithm used (DES, AES, etc.) to encrypt a file
- The user must first register in order to use the program.
- It can encrypt a photo, text file and rar file.
- Uses a hash as a password.
- Uses self created encryption algorithm.
- Removes unencrypted files after encryption.
