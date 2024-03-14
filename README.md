## Title

Freak Search

## Description

Search Engine and Web API all in one for the entire archival records of Freakonomics. This tool allows a user to find any topic, person, or quote from any Freakonomics podcast episode.

## Why?

I listen to Freakonomics every week, and often something I heard on the show enters my discussions with friends. In these discussions, I frequently found my self struggling to remember which episode I heard a quote or tidbit. This struggle has lead to me being inaccurate or providing inadequate sources. To solve this problem, I decide to build a web application that allows me to remember where I heard that interesting tidbit I want to share with friends.

## Devlog

So far I have scraped all of the existing episode transcripts from Freakonomics website.
I have taken this scraped data and built a simple API that queries all entries in the DB.
My next step is to further implement API calls for more precise information about episodes. 
Then I want to begin building the search system with a typescript react frontend.
I am at a point that I believe it will be more useful to the enduser and myself to ahve these projects to be split into two separate projects, so I intend to make freakApi a stand alone project from freakSearch
For now, I will detail how to use the existing API in the Usage section.

## Quick Start

This is a work in progress (WIP) Keep an eye out for developments in the near future.

## Usage

Presently, the github repo can be cloned and opening the freakSearch root directory in your command line and running `dotnet run` will launch the project.
However, since the database is not yet deployed, a user will not be able to successfully run any API calls.
Please stay tuned for further developments as I intend to deploy the fully functional API within a week.

## Contributing

At this time, I have no specific elements that I am looking for contributions on. As development continues, that may change. If you ahve any suggestions or questions, please do not hesitate to reach out to me: DustinYansberg@gmail.com
