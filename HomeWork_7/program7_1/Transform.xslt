<?xml version="1.0"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>All Order</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>ClientName</th>
            <th>Number</th>
            <th>AppleNum</th>
            <th>BallNum</th>
            <th>PenNum</th>
            <th>price</th>
          </tr>
          <xsl:for-each select="ArrayOfOrder/Order">
            <tr>
              <td>
                <xsl:value-of select="ClientName"/>
              </td>
              <td>
                <xsl:value-of select="Number"/>
              </td>
              <td>
                <xsl:value-of select="AppleNum"/>
              </td>
              <td>
                <xsl:value-of select="BallNum"/>
              </td>
              <td>
                <xsl:value-of select="PenNum"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>