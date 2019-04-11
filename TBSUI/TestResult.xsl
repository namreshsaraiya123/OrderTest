<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:s="http://microsoft.com/schemas/VisualStudio/TeamTest/2010" exclude-result-prefixes="s">
<xsl:template match="/">
<html>
<body>
<h2>Automation Regression Test Run Results</h2>
<P>
  <table border="1">
  <tr bgcolor="#7FFFD4">
      <th>Test Suite Started at</th>
	  <th>Test Suite Completed at</th>
	  <th>Duration</th>
	  <th>Status</th>
  </tr>  
  <tr>
	  <td><xsl:value-of select="//s:TestResultAggregation/@startTime"/></td>
	  <td><xsl:value-of select="//s:TestResultAggregation/@endTime"/></td>
	  <td><xsl:value-of select="//s:TestResultAggregation/@duration"/></td>
	  <xsl:choose>
			<xsl:when test="//s:TestResultAggregation/@outcome='Passed'">
			<td bgcolor="#CCE680"><xsl:value-of select="//s:TestResultAggregation/@outcome"/></td>
			</xsl:when>
			<xsl:otherwise>
			<td bgcolor="#FF6666"><xsl:value-of select="//s:TestResultAggregation/@outcome"/></td>
			</xsl:otherwise>
			</xsl:choose>
  </tr>
  </table>
  </P>
<h2>Automation Test Run Summary</h2>
<P>
  <table border="1">
  <tr bgcolor="#7FFFD4">
	  <th>Test Name</th>
      <th>Started at</th>
	  <th>Completed at</th>
	  <th>Duration</th>
	  <th>Status</th>
  </tr> 
  <xsl:for-each select="//s:TestResultAggregation/s:InnerResults/s:UnitTestResult"> 
  <tr>
	  <td><xsl:value-of select="@testName"/></td>
	  <td><xsl:value-of select="@startTime"/></td>
	  <td><xsl:value-of select="@endTime"/></td>
	  <td><xsl:value-of select="@duration"/></td>
	  <xsl:choose>
	  <xsl:when test="@outcome='Passed'">
	  <td bgcolor="#CCE680"><xsl:value-of select="@outcome"/></td>
	  </xsl:when>
	  <xsl:otherwise>
	  <td bgcolor="#FF6666"><xsl:value-of select="@outcome"/></td>
      </xsl:otherwise>
      </xsl:choose>
  </tr>
  </xsl:for-each>
  </table>
</P>
<h2>Automation Test Run Details</h2>
<P>
  <xsl:for-each select="//s:TestResultAggregation/s:InnerResults/s:UnitTestResult">
  <P>  
  <table border="1">
  <tr bgcolor="#7FFFD4">
	  <th>Test Name</th>
      <th>Started at</th>
	  <th>Completed at</th>
	  <th>Duration</th>
	  <th>Status</th>
  </tr> 
  <tr>
	  <td><xsl:value-of select="@testName"/></td>
	  <td><xsl:value-of select="@startTime"/></td>
	  <td><xsl:value-of select="@endTime"/></td>
	  <td><xsl:value-of select="@duration"/></td>
	  <xsl:choose>
	  <xsl:when test="@outcome='Passed'">
	  <td bgcolor="#CCE680"><xsl:value-of select="@outcome"/></td>
	  </xsl:when>
	  <xsl:otherwise>
	  <td bgcolor="#FF6666"><xsl:value-of select="@outcome"/></td>
      </xsl:otherwise>
      </xsl:choose>
  </tr>
  <xsl:variable name='nl'><xsl:text>
  </xsl:text></xsl:variable>
  </table>
		<table border="1">
		<tr bgcolor="#7FFFD4">
		<th>Test Name</th>
		<th>Data Row Number</th>
		<th>Status</th>
		<th>Error</th>
		</tr> 
		<xsl:for-each select="s:InnerResults/s:UnitTestResult">
		<tr>
			<td><xsl:value-of select="@testName"/></td>
			<td><xsl:value-of select="@dataRowInfo+1"/></td>
			<xsl:choose>
			<xsl:when test="@outcome='Passed'">
			<td bgcolor="#CCE680"><xsl:value-of select="@outcome"/></td>
			<td><xsl:text></xsl:text></td>
			</xsl:when>
			<xsl:otherwise>
			<td bgcolor="#FF6666"><xsl:value-of select="@outcome"/></td>
			<td><xsl:value-of select="s:Output/s:ErrorInfo/s:Message"/></td>
			</xsl:otherwise>
			</xsl:choose>
		</tr>
		</xsl:for-each>
		</table>
  </P>
  </xsl:for-each>
</P>
</body>
</html>
</xsl:template>
</xsl:stylesheet>