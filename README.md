# README for COP2664C Winter 2021 WebForm1.aspx

This README file provides an overview of the code found in the WebForm1.aspx file. WebForm1.aspx appears to be an ASP.NET web form page, and this document will help you understand its structure and purpose.

## Table of Contents

- [Introduction](#introduction)
- [Description](#description)
- [Usage](#usage)
- [Components](#components)
- [Contributing](#contributing)


## Introduction

WebForm1.aspx is a web form page written in C# for the COP2664C Winter 2021 project. 

## Description

This section provides an overview of the key components and functionalities found within the WebForm1.aspx file.

### Page Configuration

The code starts with page configuration settings, including the master page, language, and code-behind file. It also specifies the page's title and event wireup settings.

### HTML Content

The HTML content of the page includes a form with various input fields and buttons for capturing and displaying data. Here are some of the key components:

- Input fields for `airline_sentiment`, `airline_sentiment_confidence`, `negativereason`, `negativereason_confidence`, and `airline`.
- Buttons for saving data (`ButtonSave`) and clearing input fields (`ButtonClear`).
- Labels for displaying success and error messages (`SuccessMessage` and `ErrorMessage`).
- A GridView (`gvtweets`) for displaying rows of data with columns for sentiment-related information and a "View" link for each row.

### Server-side Code

The server-side code for this page is implemented in a separate code-behind file (`WebForm1.aspx.cs`), which is referenced in the page configuration. The code-behind file contains event handlers for button clicks and data retrieval, among other things.

## Usage

To use this web form, follow these steps:

1. Open the WebForm1.aspx page in a web browser or within an ASP.NET application.
2. Fill in the input fields with the relevant data, including `airline_sentiment`, `airline_sentiment_confidence`, `negativereason`, `negativereason_confidence`, and `airline`.
3. Click the "Save" button (`ButtonSave`) to save the data.
4. Use the "Clear" button (`ButtonClear`) to clear the input fields.
5. The success or error messages will be displayed in the respective labels (`SuccessMessage` and `ErrorMessage`).
6. The data will be displayed in the GridView (`gvtweets`), and you can click the "View" link for each row to perform additional actions.

## Components

Here is a summary of the key components found in WebForm1.aspx:

- Input fields for data entry (`txtairline_sentiment`, `txtairline_sentiment_confidence`, `txtnegativereason`, `txtnegativereason_confidence`, `txtairline`).
- Buttons for saving and clearing data (`ButtonSave` and `ButtonClear`).
- Labels for displaying success and error messages (`SuccessMessage` and `ErrorMessage`).
- GridView for displaying data (`gvtweets`).

## Contributing

Contributions to this codebase are not specified in this document. If you are working with this codebase, please refer to the development team or repository guidelines for contribution instructions.

