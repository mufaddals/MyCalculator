# MyCalculator

MyCalculator is a Ohm Value Calculator based on the Capacitory Resistor Color Code Bands explained [here](https://en.wikipedia.org/wiki/Electronic_color_code).

## User Story
<b>As a:</b> novice home owner with no professional electrician skills, <br>
<b>I want to:</b> enter the Band Colors on the dead Resistor so the system can perform the Ohm Value calculations accurately and tell me the Ohm Rating <br>
<b>So that:</b> I can  purchase a new Resistor with the matching Rating and Tolerance Level<br>

## Components
<ul>
  <li>ASP.Net MVC running on 4.5.2</li>
  <li>NUnit Test Framework</li>
</ul>

## How To Use

Hold the Resistor so that the group of Bands is to your left.

Then select the color from the drop downs in the sequence left to right.

<img src="https://preview.ibb.co/bMiOwy/ohmBands.jpg" alt="ohmBands" border="0">

Click Submit and the Ohm Value will be shown on screen

## Installation

1. Download the files to your local machine.
2. Double click MyCalculator.sln and Visual Studio will load the two projects for you:
<ul>
<li>MyCalculator</li>
<li>MyCalculator.Tests</li>
</ul>
3. Hit F5 to build and run the application.

### MyCalculator 
ASP.NET MVC application containing the Model (and Interface), View and Controller. 

#### MyCalculator.Tests
NUnit Tests 

## Thank you for this opportunity!