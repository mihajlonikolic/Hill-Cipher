# Hill-Cypher

### Introduction

[Go to VM](http://{{ vm_ip('main') }}:8000/)

This scenario should provide students with an insight into substitution ciphers and remind them of some basic mathematical operations used in cryptography.

The scenario is a Windows Forma Application which enables the encoding and decoding of text by using Hill's Cipher. This is a cipher that belongs to the group of substitution ciphers. Hill Cipher is characterized by the fact that substitution is performed by executing mathematical operations over matrices that represent an inevitable segment of cryptography.The general equation of Hill's Cipher is given below:

![Coding by Hill's Cipher]( static/4.jpg)

SSH Transport Layer Protocol Packet Formation [1](#fn1)

*   **C** \- row vector of length 3 representing the ciphertext
*   **P** \- row vector of length 3 representing the plaintext
*   **K** \- 3 x 3 matrix representing the encryption key
*   **mod 26** \- operations are performed by mod 26 (the alphabet has 26 letters)

![Cipher Block Chaining (CBC) mode encryption]( static/CBC.jpg)

Cipher Block Chaining (CBC) mode encryption [2](#fn2)

The student can see how the implementation of the CBC mode should look in practice, which helps him to understand how this type of encoding actually works.

1\. \[Protocol Basics: Secure Shell Protocol - The Internet Protocol Journal, Volume 12, No.4 by William Stallings\][↩](#ref1)  
2\. [\[https://de.wikipedia.org/wiki/Datei:CBC_decryption.svg\]](https://de.wikipedia.org/wiki/Datei:CBC_decryption.svg)[↩](#ref2)