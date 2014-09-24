<?xml version="1.0" encoding="UTF-8"?>
<!-- an xslt file is basically just an xml document -->

<!-- However, this declares that it is an "xsl stylesheet", or "xsl transform" file - each term is equally used -->
<!-- 
      The elements generated should contain absolutely NO styles whatsoever - only generate the html tags and content 
      At some point, this xslt will be inserted into another html page, and it will be styled from there
-->
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>My CD Collection</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Title</th>
            <th>Artist</th>
          </tr>
          <!-- Notice how XSLT uses xpath to select nodes - check milestone 5 for examples -->
          <xsl:for-each select="catalog/cd">

            <xsl:choose>
              <xsl:when test="artist = 'Mads'">
                <tr>
                  <td>
                    <!-- xsl:value-of selects the inner-text of the element selected. Note that we are looping catalog/cd, and only then selects the title element and displays its text-->
                    <h3><xsl:value-of select="title"/></h3>
                  </td>
                  <td>
                    <h3><xsl:value-of select="artist"/></h3>
                  </td>
                </tr>
              </xsl:when>
              <xsl:otherwise>
                <tr>
                  <td>
                    <!-- xsl:value-of selects the inner-text of the element selected. Note that we are looping catalog/cd, and only then selects the title element and displays its text-->
                    <xsl:value-of select="title"/>
                  </td>
                  <td>
                    <xsl:value-of select="artist"/>
                  </td>
                </tr>
              </xsl:otherwise>
            </xsl:choose>
            
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>