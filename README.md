# PG3D-CryptoPrefsGenerator
For Pixel Gun 3D

This project was created with [Visual Studio](https://visualstudio.microsoft.com/).

This tool allows you to encrypt and decrypt the keys and values in the com.pixel.gun3d.v2.playerprefs.xml file used to store data in Pixel Gun 3D.

**How To Use**
Using this tool is very simple. All you need is your PlayerPrefs file. Getting this requires root on Android devices and requires a jailbreak on iOS devices.
Android pref location: /data/data/com.pixel.gun3d/shared_prefs/com.pixel.gun3d.v2.playerprefs.xml
iOS pref location: *to be added later*

This is an example of one of the lines in the pref xml: <string name="AEAD%3AJOze460XrYsianVxAlVVaA%3D%3D">RKC5xwdkjhAKCGJ1CnR%2FlFdmNDdDy2xJrxb20E8naqhfHB32MzpR6Z89Jm3DzkOYGZJy%2BgUVozBl9UGJw9bm%2Bu12S3X4b%2B2dTUIGPzQQAysxHO6V</string>
**AEAD%3AJOze460XrYsianVxAlVVaA%3D%3D** is the encrypted key.
**RKC5xwdkjhAKCGJ1CnR%2FlFdmNDdDy2xJrxb20E8naqhfHB32MzpR6Z89Jm3DzkOYGZJy%2BgUVozBl9UGJw9bm%2Bu12S3X4b%2B2dTUIGPzQQAysxHO6V** is the encrypted value.
When decrypted the key is **TestKey** and the value is **TestValue** as seen [here](https://github.com/jbro129/PG3D-CryptoPrefsGenerator\Example\decrypt1.png).
When encrypting the key and value it'll look like [this](https://github.com/jbro129/PG3D-CryptoPrefsGenerator\Example\encrypt.png).
Encypted keys will always stay the same. This means that the key **TestKey** will always be **AEAD%3AJOze460XrYsianVxAlVVaA%3D%3D** when encrypted.
Encrypted values can change. **RKC5xwdkjhAKCGJ1CnR%2FlFdmNDdDy2xJrxb20E8naqhfHB32MzpR6Z89Jm3DzkOYGZJy%2BgUVozBl9UGJw9bm%2Bu12S3X4b%2B2dTUIGPzQQAysxHO6V** when decrypted using its key equals **TestValue** while **XniPbYoCld%2BmeqaYEEOlx91Au%2BlLiOlY5kfbp%2BYLuLbveiBBAGeezO9ziMwOyMkaarD3UwvqVirRHV2zWlySnOe9mWsBeA5Fs13zTojh5NfOnMNJ** when decrypted will give the same value.
[Decryption 1](https://github.com/jbro129/PG3D-CryptoPrefsGenerator\Example\decrypt1.png).
[Decryption 2](https://github.com/jbro129/PG3D-CryptoPrefsGenerator\Example\decrypt2.png).

**You cannot decrypted a value without the correct key**
Both are needed in order to decrypt successfully. 
Trying to decrypt invalid keys or invalid values will result in [this](https://github.com/jbro129/PG3D-CryptoPrefsGenerator\Example\decrypt-invalid.png).

Example Player Prefs File: [com.pixel.gun3d.v2.playerprefs.xml](https://github.com/jbro129/PG3D-CryptoPrefsGenerator\Example\com.pixel.gun3d.v2.playerprefs.xml)