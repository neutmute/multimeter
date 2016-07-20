<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="Multimeter.Config" xmlSchemaNamespace="Multimeter.Config" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="MultimeterConfig" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="multimeterConfig">
      <elementProperties>
        <elementProperty name="Publishers" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="publishers" isReadOnly="false">
          <type>
            <configurationElementCollectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PublisherConfigCollection" />
          </type>
        </elementProperty>
        <elementProperty name="KeenIO" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="keenIO" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/KeenIOConfig" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElementCollection name="PublisherConfigCollection" xmlItemName="publisher" codeGenOptions="Indexer, AddMethod, RemoveMethod, GetItemMethods">
      <itemType>
        <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/PublisherConfig" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="PublisherConfig">
      <attributeProperties>
        <attributeProperty name="AssemblyName" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="assemblyName" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="AssemblyType" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="assemblyType" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="KeenIOConfig">
      <attributeProperties>
        <attributeProperty name="ProjectId" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="projectId" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="WriteKey" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="writeKey" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="SolutionConfig">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false" documentation="Name of the application">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Project" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="project" isReadOnly="false" documentation="The type of project: Web.UI, Web.API, Windows Service">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Environment" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="environment" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>