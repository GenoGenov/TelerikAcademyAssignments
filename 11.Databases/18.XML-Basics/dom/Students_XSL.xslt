<?xml version="1.0"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
      <h1>Students</h1>
      <xsl:for-each select="/students/student">
        <div style="display:inline-block; marging:10px; border:1px solid black">
          <h3 style="color:green">
            <xsl:value-of select="name"/>
          </h3>
          <h4>Sex: </h4>
          <span>
            <xsl:value-of select="sex"/>
          </span>
          <h4>Birth Date: </h4>
          <span>
            <xsl:value-of select="birthDate"/>
          </span>
          <h4>Phone: </h4>
          <span>
            <xsl:value-of select="phone"/>
          </span>
         <h4>Email: </h4>
          <span>
            <xsl:value-of select="email"/>
          </span>
         <h4>Course: </h4>
          <span>
            <xsl:value-of select="course"/>
          </span>
        <h4>Speciality: </h4>
          <span>
            <xsl:value-of select="speciality"/>
          </span>
        <h4>Facoulty Number: </h4>
          <span>
            <xsl:value-of select="facoultyNumber"/>
          </span>
        <xsl:for-each select="/students/student/exams/exam">
          <h5>Exam: </h5>
          <span style="color:red">
            <xsl:value-of select="@name"/>
          </span>
        <h5>Tutor: </h5>
          <span>
            <xsl:value-of select="tutor"/>
          </span>
        <h5>Score: </h5>
          <span>
            <xsl:value-of select="score"/>
          </span>
        </xsl:for-each>
        </div>

      </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>
