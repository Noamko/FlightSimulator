# Flight Simulator Project
This application simulates a flight for the flight inspector & pilots that need to study or inspect the flight.
The flight data receive via *.txt* file, also this project heavily controlled by events so we based most of our code on **MVVM**  **Architectural Pattern**
- **Pay attention** when we use the linear detector the program **takes time!**

## Flight Data
- Current & Length time of the flight.
- Steering mode via Joy-Stick, Sliders and Flight Instruments.
- List of all the elements of the flight.
- Information about each element of the flight shown by 3 charts.	
	> Regular chart that shows the **value** by the **time**.
	> **Linear regression** chart for each element .
	> Third chart represent the **most correlative feature** that exists.
- Graphic display of the plain over the earth.
- Extra window to represent the DLL file and his detection on the flight. 
- The DLL file must use the program API.
	> API- getFunc(),getAnomalyCount(),getDiscription(),getTimeStep(),
	> createSimpleAnomalyDetectorInstance(),detect(),learn().
	* createSimpleAnomalyDetectorInstance - makes a new instance of the Anomaly Detect.
	* learn- (offline learning stage) setting the standard flight data.
	* detect- (online anomaly detection) checking if the data anomalies.
	* getAnomalyCount- returning  the number of anomalies.
	* getDiscription- returning the names of the anomaly. 
	* getTimeStep - returning the time step of the anomaly.
	* getFunc() - returning  the graphical view of the detector chart. 

### special features
- Menu options to show the flight or detect the flight.
- joy-Stick display, allocates the aileron & elevator data.
- Sliders display the rudder & throttle in a scale of the interval [0,1].
- Flight Instruments displays the level line of the plain.
- After the first run the location of the files will be saved, so to run the same files will be easier.
- To set a new current flight time we can use a slider or enter the percentage of the flight : 
	> To start from the beginning we enter 0 as start at 0%
	> To jump to the middle we enter 50 as 50% of the flight
- Graph that shows the anomaly detection on the loaded DLL file.

## Math knowledge
- At the Class *JoyStick_view.xaml.cs & DataViewer.xaml.cs*  we implement a function that re-maps a number from one range to another so the Joy-Stick stays in the range of his base, the mathematical explanation can be found [her]( https://stackoverflow.com/questions/5731863/mapping-a-numeric-range-onto-another)
- To calculate the correlative feature we used [probability theory](https://en.wikipedia.org/wiki/Probability_theory "Probability theory") and [statistics](https://en.wikipedia.org/wiki/Statistics "Statistics") function as [Pearson](https://en.wikipedia.org/wiki/Pearson_correlation_coefficient), [Variance](https://en.wikipedia.org/wiki/Variance), [Covariance](https://en.wikipedia.org/wiki/Covariance) and [Linear Regression](https://en.wikipedia.org/wiki/Linear_regression)

## Files 
### Main Classes
- *FlightController* - The **main** class of the project, sending the data to the simulator, and notifying by an event that the data of the flight changed  
- *PassData_VM* - Part of the **MVVM** Architectural Pattern (a model that created for the view) and contains all the raw data as **property** that we want to display in the view classes 
- *AnomalyDetector* - This class handles the DLL files and can detect flight anomalies 
- The *LineChart_model*, *LineChart_VM*, *LineChart_view*, used **MVVM** to calculate data and binding theme to the charts
- The *FileHandler*, *FileLoader_VM*, *FileLoader* use **MVVM** to bind the file location data to be used in the program
- The *MediaPlayer*, *MediaController_VM*, *MediaController* , use **MVVM** to bind the data pace and setting the flight position of the record.
-  The *JoyStick_view*, *PassData_VM*, *FlightController* use **MVVM** architectural  that bind to the data of the flight, so we get a moving Joy-Stick that shows the current steering of the flight.
- mvvm dll **update**
- DataCalculations - make all the math calculations that needed for the charts
- CSVParser - interface so we can added another way to read the data.
- Also we implement **Singleton Pattern** on the following classes: *FlightController*, *mediaController* as we want to make sure that only one class to be created, that control all the flights (only one flight per time).
- FlightControllerEventArgs - build in class that used in event (data change) to read the data of a current line.

## Installations & Settings

- Download [VS_community](https://visualstudio.microsoft.com/vs/community/), .net framework version 5.0, Desktop development with c++
- Add to NuGet Packages : OxyPlot.wpf (ver. 2.0.0)
- Add to NuGet Packages : ncalc (ver. 1.3.8)
- Download [flightSimulator](https://www.flightgear.org/) 
- open app --> settings --> at Additional Settings past:
	> --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
	--fmd=null
- when running the simulation hit **fly** button on the lower left corner.
- All the **CSV** files must be without labels 
 
## UML 
[Link](https://www.planttext.com/api/plantuml/svg/jLbRRziw4dxNhz3ZBbmVRC-ZKNIFQYkkjxu8bk9sRn0KYNQ4oA8WqKwpsVxtdI5r8KLAILhiIrFDdTyCXqFwZuf59RkSCwjwIFCYAgEp7MTHLJcCbUdTXP5LJ7C__G-n_sBTPEdfdirfpagQPQIqwNHgtopdMKfoDi3bn4N48YygArAQfJOaIQEEPgtJdCpl8R3mJ1EIIPPU47gD8Gnc7cNn9OjOIlFAkaapigPHGihmi16-WF8voXCqCVSF8dJxmtz_-qrVq6fBMNfyyafQa98zWRVyH99QMBOyAjaF_2MhJNHli8aXw2GZREuL4kgKfqfUSyTlsHA-rvGySbiT2Vnr0BIuTdZ8aZrLdgtHnIbkNYSeZ5eUL3Vchqrslx36h4dArYPAywzfdj17ivq-NqfRJHPfQiL4UhmiUZBl2tHw2pLNKwGi2ntBlwUFJbfM1O5uqO0ShgOfImlLZANiaf1NgjRIN7MHbYJ6xVGwtLQSA_yzUjp30hsKnVUlqvSrhB_H9v-byKDNWwFwYhZLxmRchgKPGTu1z87N_LVptMDf5MBnLYiPUxPiUtezpnGhG3h6CrqRw3Tnc83KRG7_akHFVvxPLvecoAa8u-X8j8bFs64Z2vsZ0ZyJUhdBYFMZ3aThqS_Mr3wUmfZt-LdNyQTsmU6PQO3Pm3jZOSx47odggPt0OhGcR4sdriJEe3b0msrZdDW5LBRqUI9iUpdVaN9tn8rT8IlbeUHyqxQYEjeSgNepInRzz8n1427UCT8SZiOy9ZCR_aAzwFXZikiUmOE7sFhBCYoKota3kA5DWjtLHejIQY59NVIy_pQjf4jRdHR8LfEf82wQL5Mi914KrfQmHre--FpJcZwMASD0nFTN_WLhhs2PEUnGT7n7QMPDQWBY8mW-oIKOvncjIFkfLbAtF0ojkeP7w8G8Qvdc9skQOHwRpt_-svhYIiDxWiS40fZoHX6LJnyWqUzgkOz2xDFJDZeJHKZmtxNsG19bP0-yrdX46B6ksxYOB4L6Rqfwncf3wJfgP1b8njfip8XWEmrSQrT2FEDOtlrWVrXWX9J7A2PsEumyZox0bbVG2xF9JUziWTHKOYU0AH-FX7fZ9UGONJ8cauvmQ72pzNSkhxgcfTN-akVWiAwNgRQV-aE7LGCGK1PbGNfMi0Nw_5AMKCfzZjeWJZIWtPVn8EzQ1FGl6NpZ-YVw-YUzzKyCwv_qrozdqJnWF5k37RWTk9v5sH-Yx4AgiSpRRTLrMDbA499DssuzzmVcvw7JnmObF460rKiaf_Uh64WOU9PMp1mtE7uWoHhu7tY_e13fnu-eno3XFelEXK2Mdsrm9qcgWCRGM5kgyLYnCREs2FQ5SW1HqMpb8_E4-wVYRSyOOQV5KUYfpcbPHdYu9EhEHpQslQZSazFkY6848xvocU1IPAJpyKxnXcRvHoNqXFcn-2Pn3GXPHnNp1NPZ2XmqPMk0aLnBg11hJokGwI4xiti4vTpIAmxdiNO0okJv7ckGbkU8GV4gAEePc-9wS9WAVPA96REVQDtpOSFzyfANNOiR0t1oVifqReltejOuPfpmkqfe2k_5cfjS-0hg8gk9lmWjr_RK_1qsePv2fEAM72aUaEZARFq6sQqAcN2L4oZunef9l-2bFUIZxO_TLKfqgE_dh8ZOlPmY63GQKbeAql7K5ufoUewo9v3rUfnN9K_V9X18pzBaUFBKE2QwkqaToDmGo4_NWQtW9UxTxVvIh-A8rps97sxIFAtaEyDqZkJLSLUGN5tw7Sj3S9r_EsSX39dnWu5v1_FACDFzvfgPrUNkdB9XHMUxspZhbUjh8lg2yPOl3h7xcN85__aSGvaQqWpKBjCIqP1ieFv_ysruvX4DpdmbQw2GXwzL3YU5tATmSygZLasABXNfqKwKKPdqOWi47RYkyWdh9U1P4ryFJotqPYoecTBmgB7ZZYTP_TLSI4EL_EB4yn2ts9klzR_K-vjqJgFwRMTc7-5UpO-fg7wpaKXuqO8LByX98c8eAgN0nuIEPEDr8I5-bXOAaTsNbB5CTb1UaWGNsWK1kx2akKI1a_eQCIe9lNvxwXD0LpTjsJWQ59ogeO7KpmP0aBxlOu94JuMbfleQD4tvQl0WjOyGqdH8UDleGzVk-FOHiIcoYOyl-wAwbZ1foWWTUpLdhi9ZrordQkTiIwnsoLkjafNc8glSTiU3UjLxZTrhSkBXiptL30-cmA5PSesozfshYxyvLB2ncOyRtj_CB6npE48Ed65rGzEvU9_1IIYiifGVK7YPCnHsNsv38PGrER9F5yPelg2F-Hl4RmlbcBJ5hppA6p2YMEDOAC-F7AZs9jLxHWHRagbwHt5JRxVK6MeVY7ysgCwK_5OihFsqEUNfUE2jzgLNLY0Spk58GskTQBjg0aM5tGccOOH62yyHGyM2CC2EYbsHP5aefbuuT2ec3Hf9BJQpLpdp6D_ojOKzAMZ93XgRjzFgCHH6q7_BcwnXE-TRlALbSiWY69c2xn9f5PTfqIoYEyc15_3hFYcQrpD1lRdaiIO-dPBlS2FCULmP-fVy9AtZDiQu971K-EaPxjSzh5RrwvGYdwHLKJzhGYHO82SjlfhQMr7VfOvNb2Hunmnenwi3nsdbNhJ66FxofUKT6i2kOv_JIyuK1g8aUMdg0XhYCJrTogZPK1DdjNRtkwrM51DtxHwSOBVNEVlRnS8rq6_MZkVhP7_j12QovxgByDFU-U8Qd6-NgwtxFWm-xtT1i1wK-Fr5YVUXTxlnXlK7k6jt7knNyq7jcZ-e_ormzrjd7NgxhoQe7EysNBfRTsz6611R1RSBDrouImDtjrsEyPtr67U_Mw_D76yLp3-RMPzTPx7QBirCVmM-_FNA6mXdjHUv_XBepEKQbFtrpe1XgxVQBbPp1Ahv7z26BUBgDox0BqctYDoCAdXxr_TlzoxAcqM3seuff17uHlM64s9KQmhhZTvgjM5dxdQ-MxmUjKRyHSoMdlzQcwheSh-xtIv6IaUHFhZx0Fwx5fMXItUIexMySPPR5mo5yzt6StpPm_WUmFBtlwoWepc0i5Ie3KFN2MxtMsD580CwWw6dyLKsYnpP63UBpL3B2_TUZoTDqlrNSpuu3FsqoqU7D6R6LtmKM-L7oj_5yRqH2V-0AuiZ7ziouvFCIFEKRGaCV_BBmpIwdfmyEKHbzmDQmuhfTNSC7YdCq9KwO-6ZjvDbStgjP8K2feIAvkDAdX2gr27kkzVeQb4q3-pyvRvxmbT_JXI_WjGkk83iGFsvm6p8bYtLFo249JaDUQpDRjhGzLyX57O7nby53z3JQ6n8c3dNaquyY4b69O9B0p5LRCh5YINrt5IEyiXBhyOw54O-sl-ISZucs0stc8MhbfUhKYSe9Q4WIMhOMAPtB2XesTerAkLFDLroiZfEJ_wWt6udW6IF4hULvTKFx0CL-aDSXVuWUN8vP_y3)
## Video
[Link](https://youtu.be/_7DKTyfYoCk)
## flow chart
```mermaid
graph LR
Z((start program)) --> A
A((Main Window)) -- Run --> B((file loader))
B -- Data Source  --> A
A -- Run At Command --> C((Flight Controller))
A -- Run At Command --> D((DLL))
C -- Initialize --> E((Media Play))
E -- Pace --> C
C -- Data Reading --> C
C -- Data Updated --> F((Model Classes)) -- Event --> G((VM Classes)) -- Data Bind--> H((View Classes)) 
D --Learn & Detect -->I((Anomaly Charts))

