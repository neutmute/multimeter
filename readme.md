# Multimeter#
It measures things.

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