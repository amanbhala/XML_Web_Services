# XML_Web_Services
In this project a XML file and XSD file is created which follows the below structure.

Web service (.svc) containing below Web operations are created:
- Web operation “verification” takes the URL of an XML (.xml) file and the URL of the
corresponding XMLS (.xsd) file as input and validates the XML file against the corresponding
XMLS (XSD) file. The Web method returns “No Error” or an error message showing the available
information at the error point. You must use the files that you created in this assignment, with and
without fault injection, as the test cases. However, your service operation should work for other test
cases (other XML file and its corresponding XSD file) too.
- Web operation “search” takes the URL of an XML (.xml) file and a key (e.g., the element name
Headquarter) as input. It returns the node’s content information related to the search key, for
example: park name, number, departure port, etc. Your program must also read any attributes.
Attributes should be searched too. If there are multiple occurrences, you must return all of them. In
this question, you can use DOM or SAX model. In the GUI (Question 3), you can display them all
or once at a time through a “Display Next” button.
