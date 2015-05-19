<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="MultiLayerProj" generation="1" functional="0" release="0" Id="abc88521-1390-4976-b0e0-5166597e64fd" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="MultiLayerProjGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebRole1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/MultiLayerProj/MultiLayerProjGroup/LB:WebRole1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRole1:PriceCompareDB" defaultValue="">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWebRole1:PriceCompareDB" />
          </maps>
        </aCS>
        <aCS name="WebRole1:StorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWebRole1:StorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWebRole1Instances" />
          </maps>
        </aCS>
        <aCS name="WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WorkerRole:PriceCompareDB" defaultValue="">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWorkerRole:PriceCompareDB" />
          </maps>
        </aCS>
        <aCS name="WorkerRole:StorageConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWorkerRole:StorageConnectionString" />
          </maps>
        </aCS>
        <aCS name="WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/MultiLayerProj/MultiLayerProjGroup/MapWorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebRole1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebRole1:PriceCompareDB" kind="Identity">
          <setting>
            <aCSMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1/PriceCompareDB" />
          </setting>
        </map>
        <map name="MapWebRole1:StorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1/StorageConnectionString" />
          </setting>
        </map>
        <map name="MapWebRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1Instances" />
          </setting>
        </map>
        <map name="MapWorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWorkerRole:PriceCompareDB" kind="Identity">
          <setting>
            <aCSMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRole/PriceCompareDB" />
          </setting>
        </map>
        <map name="MapWorkerRole:StorageConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRole/StorageConnectionString" />
          </setting>
        </map>
        <map name="MapWorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebRole1" generation="1" functional="0" release="0" software="E:\Dropbox\Dropbox\Colman\Cloud\MultiLayerProj\MultiLayerProj\csx\Release\roles\WebRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="PriceCompareDB" defaultValue="" />
              <aCS name="StorageConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
        <groupHascomponents>
          <role name="WorkerRole" generation="1" functional="0" release="0" software="E:\Dropbox\Dropbox\Colman\Cloud\MultiLayerProj\MultiLayerProj\csx\Release\roles\WorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="PriceCompareDB" defaultValue="" />
              <aCS name="StorageConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;r name=&quot;WorkerRole&quot; /&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/MultiLayerProj/MultiLayerProjGroup/WorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WebRole1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyUpdateDomain name="WorkerRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WebRole1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyFaultDomain name="WorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WebRole1Instances" defaultPolicy="[1,1,1]" />
        <sCSPolicyID name="WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="31dd85c5-b474-41cb-856b-349c7b20045e" ref="Microsoft.RedDog.Contract\ServiceContract\MultiLayerProjContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="ac91f0eb-e3b4-4fa7-9d16-ff1ead676217" ref="Microsoft.RedDog.Contract\Interface\WebRole1:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/MultiLayerProj/MultiLayerProjGroup/WebRole1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>