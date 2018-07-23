# Hill-Cypher

### Introduction

This scenario should provide students with an insight into substitution ciphers and remind them of some basic mathematical operations used in cryptography.

The scenario is a Windows Forma Application which enables the encoding and decoding of text by using Hill's Cipher. This is a cipher that belongs to the group of substitution ciphers. Hill Cipher is characterized by the fact that substitution is performed by executing mathematical operations over matrices that represent an inevitable segment of cryptography. The general equation of Hill's Cipher is given below:

![Equation of Hill's Cipher]( static/4.jpg)

Equation of Hill's Cipher[1](#fn1)

*   **C** \- row vector of length 3 representing the ciphertext
*   **P** \- row vector of length 3 representing the plaintext
*   **K** \- 3 x 3 matrix representing the encryption key
*   **mod 26** \- operations are performed by mod 26 (the alphabet has 26 letters)

All operations in this scenario are executed by mod 30 (26 letters of alphabet + 4 special characters '.' ',' '!' '?'). For coding and deconding you can use this charachters, otherwise the program will report an error. Below you can find examples of encoding, decoding and breaking up of the code of Hill's Cipher.

### Examples

Consider the plaintext “paymoremoney” and use the encryption key

17  17  5

21  18  21

2   2   19

#### Encoding

The first three letters of the plaintext are represented by the vector (15 0 24). Then (15 0 24)K = (303 303 531) mod 26 = (17 17 11) = RRL. Continuing in this fashion, the ciphertext for the entire plaintext is RRLMWBKASPDH.

#### Decoding

Decryption requires using the inverse of the matrix K. We can compute det K = 23, and therefore, (det K)-1mod 26 = 17. We can then compute the inverse as

4   9   15

15  17  6

24  0   17

This is demonstrated as

![.]( static/5.jpg)

It is easily seen that if the inverse matrix K is applied to the ciphertext, then the plaintext is recovered.

#### Breaking up of the code

Suppose that the plaintext “hillcipher” is encrypted using 2 x 2 a Hill cipher to yield the ciphertext HCRZSSXNSP.Thus, we know that (7 8)K mod 26 = (7 2); (11 11)K mod 26 = (17 25); and so on. Using the first two plaintext–ciphertext pairs, we have

![.]( static/6.jpg)

The inverse of X can be computed:

![.]( static/7.jpg)

so

![.]( static/8.jpg)

This result is verified by testing the remaining plaintext–ciphertext pairs.  
Now you can use this scenario to practice all three functionalities.
