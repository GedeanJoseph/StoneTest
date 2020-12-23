# StoneTest - WebCrawler

This is a project created to show one of the possible ways to recover content from the internet in an automated way.

For this example, our target will be the intriguing and random phrases from the website["Lero Lero"](https://lerolero.com/) in an automated way so that in a second step it is submitted to the site ["mothereff.in"](https://mothereff.in/byte-counter#) to count the content in bytes;

In a complementary way, we can also appreciate the architecture used preserving the contexts of individual responsibilities and abstracting functions and elements of common access.

We also have an interesting approach to using Selenium in a current version and also exploring the performance gain by using the ["--Headless"](https://developers.google.com/web/updates/2017/04/headless-chrome) function.

Some calculations and functions for managing volume of data and flow of control of system execution

Enjoy ^.^

## Prerequisites
- Google Chome **v87^** *[Check your Version](https://www.google.com/chrome/update/)*
- Dot Net Core **V3.1^**
- [googledriver.exe **v87**](https://sites.google.com/a/chromium.org/chromedriver/downloads) *(Already available in the project inside the driver folder of the webDriver project)*
   - ### Nuget Packages
     - Selenium.WebDriver **v3.141.0**
     - Microsoft.Extensions.Configuration.Json **v5.0.0**


## Execution

A. I suggest running via Debug in Visual Studio. Thus, the folder for generating the final file will be **"c:\temp"**

B. You can also run through the prompt and explore passing parameters via the command line.

1. Passing just the only **(mandatory)** folder path **parameter**. This run will generate the output file in the "c: \ Temp2" folder with the default buffer size of 1MB and the default File size of 100MB
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe "c:\temp2"
```

2. Also passing the size of the generated buffer. This form will override the default value of 1MB
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe "c:\temp2 5"
```

3. Passing the buffer value and also the file size value. Standard file size is 100MB
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe "c:\temp2 10 50"
```

4. In the latter on load, it is also possible to eliminate the "Headless" configuration so that it is possible to visualize the browser being launched on the screen and monitor the interaction with the pages.
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe "c:\temp2 10 50 0"
```
### Resume of execution Start
#### List Parameters
     1. File Path = Destination directory where the file will be generated with all the buffer produced by the crawler
     2. Buffer size in Mega Bytes that should be taken into account when saving the file.
     3. Maximum size that the file must reach to complete the execution of the system.
     4. Parameter that will allow changing the default behavior of the system to run in headless mode. By default it will run in activated mode.

## Project Status
This project is under construction and probably in constant evolution. The initial proposal is met, however, the adopted architecture allows the exploration of many techniques and application of evolution. I will continue to have fun with him.
