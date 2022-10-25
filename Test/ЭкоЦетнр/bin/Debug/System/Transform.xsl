<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
  	<head>
  		<title>HTML-отчет</title>
  	</head>
  	<style type="text/css">
  		TABLE {
    		border-collapse: collapse; 
    		width: 300px;
   		}
   		TH { 
    		background: #fc0;
    		text-align: left;
   		}
   		TD {
    		background: #fff;
    		text-align: center;
   		}
   		TR, TH, TD {
    		border: 1px solid black;
    		padding: 4px;
    		font-size:24px;
   		}
   		h2{
   			font-size:32px;
   		}
  	</style>
	<body>
		<h2>HTML- отчет</h2>
	    <table border="1">
	      <tr>
	        <th>Title</th>
		<th>Author</th>
		<th>Category</th>
		<th>Year</th>
		<th>Price</th>
	      </tr>
	      <xsl:for-each select="Book/BookList/Book">
	      <tr>
	        <td><xsl:value-of select="Title" /></td>
	        <td>
	          <xsl:for-each select="Author/string">
	             <xsl:value-of select="."/>;
	          </xsl:for-each>     
	        </td>
	        <td><xsl:value-of select="Category" /></td>
	        <td><xsl:value-of select="Year" /></td>
	        <td><xsl:value-of select="Price" /></td>
	      </tr>
	      </xsl:for-each>
	    </table>
	</body>
  </html>
</xsl:template>
</xsl:stylesheet>

