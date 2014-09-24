﻿<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
      <h2>My CD Collection</h2>
      <xsl:apply-templates/>
  </xsl:template>

  <xsl:template match="cd">
    <p>
      <xsl:apply-templates select="title"/>
      <xsl:apply-templates select="artist"/>
    </p>
  </xsl:template>

  <xsl:template match="title">
    Title: <span class="title">
      <xsl:value-of select="."/>
    </span>
    <br />
  </xsl:template>

  <xsl:template match="artist">
    Artist: <span class="artist">
      <xsl:value-of select="."/>
    </span>
    <br />
  </xsl:template>

</xsl:stylesheet>