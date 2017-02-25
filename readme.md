![](https://raw.githubusercontent.com/neutmute/multimeter/master/SolutionItems/multimeter128.gif) 
# Multimeter#
It measures things!

Multimeter abstracts various third party metering services such as New Relic from your code. Using Multimeter  prevents direct coupling to a particular service provider. Routing timing and event measurements to a different service is as easy as changing the `publisher` configuration in your `app.config`. 

[![multimeter MyGet Build Status](https://www.myget.org/BuildSource/Badge/multimeter?identifier=11124d6e-d5a1-407e-952b-7be2ca8c6007)](https://www.myget.org/) ![Version](https://img.shields.io/nuget/v/multimeter.svg)


### Usage Example

	using (new SelfPublishingTimedMetric("S3", "backup-download"))
    {
        // Do your expensive work here
    }

### Example New Relic Configuration

	<?xml version="1.0" encoding="utf-8"?>
	<configuration>
		<configSections>
			<section 	name="multimeterConfig" 
						type="Multimeter.Config.MultimeterConfig, Multimeter.Config, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
		</configSections>
	   
		<multimeterConfig xmlns="Multimeter.Config">
		  <publishers>
		    <publisher assemblyName="Multimeter.Publisher.NewRelic" assemblyType="Multimeter.Publisher.NewRelic.NewRelicPublisher"/>
		  </publishers>
		</multimeterConfig>
	 
	...
	 
	</configuration>

### Example Loggly Config

	<?xml version="1.0" encoding="utf-8"?>
	<configuration>
	  <configSections>
	    <section name="multimeterConfig" type="Multimeter.Config.MultimeterConfig, Multimeter.Config, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
	    <section name="loggly" type="Loggly.Config.LogglyAppConfig, Loggly.Config, Version=3.5.0.0, Culture=neutral, PublicKeyToken=null"/>
	 </configSections>
	   
	<multimeterConfig xmlns="Multimeter.Config">
	  <publishers>
	    <publisher assemblyName="Multimeter.Publisher.Loggly" assemblyType="Multimeter.Publisher.Loggly.LogglyPublisher"/>
	  </publishers>
	</multimeterConfig>
	 
	  <loggly xmlns="Loggly" customerToken="your token here" />
	 
	</configuration>

### Example KeenIO Config
	<?xml version="1.0" encoding="utf-8"?>
	<configuration>
	  <configSections>
	    <section name="multimeterConfig" type="Multimeter.Config.MultimeterConfig, Multimeter.Config, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
	  </configSections>
	   
	 
	<multimeterConfig xmlns="Multimeter.Config">
	  <keenIO projectId="5428cdb980a7bd37f451e103" writeKey="01d8a7220a4ac969863"/>
	  <publishers>
	    <publisher assemblyName="Multimeter.Publisher.KeenIO" assemblyType="Multimeter.Publisher.KeenIO.KeenIOPublisher"/>
	  </publishers>
	</multimeterConfig>
	 
	...
	 
	 </configuration>