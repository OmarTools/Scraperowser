# Scraperowser: A Simple Web Resource Extractor

Scraperowser is a lightweight web browser application built with CefSharp. It allows you to navigate to a webpage and extract resource URLs (like images, scripts, stylesheets) found within the HTML content. Extracted URLs are then saved to a text file for further processing or analysis.

## Features:

Leverages CefSharp for Chromium embedded web browsing.
Extracts resource URLs using regular expressions.
Saves extracted URLs to a specified file.
## Getting Started:
Clone the repository: 
`git clone https://github.com/OmarTools/Scraperowser.git`
Install required dependencies (refer to CefSharp documentation).
Configure the urlsFilePath variable in Form1.cs to your desired location for saving URLs.
Build and run the application.

## Potential Use Cases:
Downloading website assets for offline viewing.
Identifying resources used by a webpage for further analysis.
Building a simple web scraper for basic tasks (consider ethical implications of web scraping).
**Note:**
This is a basic implementation and can be extended for more advanced functionalities. Refer to the CefSharp documentation for further exploration.
