# Crimey Boyz

In a world where monolithic corporations are left unchecked, one bank is all that stands between five hapless criminals being dirt poor and filthy rich.  
Crimey Boyz is an epic platformer party game where up to five players can work together to pull off the most ridiculous heist in the galaxy.  
Work together or alone to pay off your space debt and profit as much as possible.

This project was developed by team Scruffle for the course DECO3801 at The University of Queensland during Semester 2 2019.

## Getting Started

These instructions step though how to get a the project up and running on your local machine for development purposes.  
Please note that this guide is written for windows.

### Prerequisites

* [Unity Hub](https://unity3d.com/get-unity/download) installed
  - Ensure you are signed into your Unity account & Unity Hub is licensed (Personal Edition was used for this project)

### Installing & Setup - Game Development

1. Install unity 2019.2.5 (Developed on Unity 2019.2.5f1 but the latest 2019.2 should also work)
  * Open Unity Hub -> Installs -> Add -> "Unity 2019.2.xx"
    - Alternatively, download from https://unity3d.com/get-unity/download/archive
  * Ensure "Android Build Support" and "Android SDK & NDK Tools" modules are selected
2. Add the CrimeyBoyz project in unity
  * Unity Hub -> Projects -> Add
  * Navigate to and select the "CrimeyBoyz" folder from this repo
3. Open the poject and wait for unity to download libraries & packages

### Installing & Setup - Website Development

1. Install Xampp
  * Download and install XAMPP from https://www.apachefriends.org/index.html
  * Follow the instructions on the website and installer. No specific settings needed.
2. Setup the database
  * Once XAMPP is installed, open the control panel (the default location is C:\xampp\xampp-control.exe)
  * Click “Start” for the apache and mysql services
  * Once the services have started, click the “Admin” button for MySQL
    - This should open a web page to the local phpMyAdmin portal
  * Within phpMyAdmin click the “import” tab at the top of the page.
  * Click “Choose File” and select the “ServerConfig/CrimeyBoyz.sql” file from this repo
  * Clicking “go” at the bottom of the page will result in a new “CrimeyBoyz” database begin setup on the local machine with correct schema, although it will have no user info or data.
3. Copy in website files
  * Open the “htdocs” folder for xampp (the default location is C:/xampp/htdocs)
  * This will have default apache guides. They can be removed or left as is.
  * For a clean website setup, it is recommended to remove everything from the htdocs folder.
  * Copy all the contents in the “Website” folder in this repo into this “htdocs” folder
4. Change the website config for local setup
  * From the “htdocs” folder, navigate to “/application/config” folder
  * Open config.php and go to line 27
  * Set the ‘base_url’ variable to be the local machine. (E.g. 'http://localhost')
  * This will change links and buttons on the website to redirect to the local machine instead of redirecting back to the production url
  * Next, open database.php from the same folder
  * Down the bottom of the file, change ‘username’ and ‘password’ to match the local database login
    - If xampp was just installed, the default username is ‘root’ and has no password.
5. Test that you can load the website
  * If all is working, the website should now viewable from http://localhost 

## Built With

* [Unity](https://unity.com/) - Development environment, game engine, and compiler
* [MLAPI](https://mlapi.network/) - Foundation for network communication and networked objects between the Windows and Android builds of the game.
* [Lightweight Render Pipeline](https://unity.com/srp/universal-render-pipeline) - Customisable renderer, optimised for real-time performance on resource constrained devices, such as mobile and portable devices.
* [Code Igniter](https://codeigniter.com/) - PHP based MVC (Model-View-Controller) web framework used for the project's website.

## Authors

* **Mats Brokvam**
* **Howard (Zhe) Chen**
* **Justin Dong**
* **Owen A. Peries**
* **Jessica Tyerman**
* **Cameron Weber**

## Acknowledgments

* **Jason Weigel** - Client

* **Music** - The music used for this project was not composed by the team and the sources are as follows:
  * Swing-Time by **Music By Pedro**: https://www.youtube.com/watch?v=nDDfWDvVROI
  * New York, 1924 by **Ross Bugden**: https://www.youtube.com/watch?v=wnPLbKmYCKQ
  * Swing has Swung by **Swilverman Sound Studios**: https://www.youtube.com/watch?v=JNj1WRRg_eQ
  * Elevator Bossa Nova by **Bensound**: https://www.bensound.com/royalty-free-music/track/the-elevator-bossa-nova 
