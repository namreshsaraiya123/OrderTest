Feature: PlaceOrder
	Place new order, Update the existing order, delete the order

Background: Visit the website and login
    Given user have visited the testcomplete home page 
	And user is not logged in
	And user logs in 

	@testcomplete
	Scenario Outline: Place an order
	Given user clicks on Order button
	When user provides the mandatory fields for the order
	| Product   | Quantity   | CustomerName   | Street   | City   | State   | Zip   | CardType   | CardNo   | ExpDate   |
	| <product> | <quantity> | <customername> | <street> | <city> | <State> | <Zip> | <cardtype> | <CardNo> | <expdate> |
	And user clicks on the process button
	Then verify the order is placed
	When user clicks on the logout button
	Then verify the user is successfully logged out
	

	Examples: 
	| product     | quantity | customername | street         | city      | State | Zip  | cardtype | CardNo           | expdate |
	| MyMoney     | 2        | Namresh      | Tulip Crescent | Melbourne | Vic   | 3155 | Visa     | 4532411343848790 | 09/22   |
	#| ScreenSaver | 1        | Namresh      | Tulip Crescent | Melbourne | Vic   | 3155 | Visa     | 4532411343848790 | 09/22   |
	#| FamilyAlbum | 1        | Namresh      | Tulip Crescent | Melbourne | Vic   | 3155 | Visa     | 4532411343848790 | 09/22   |

@testcomplete
Scenario Outline: Update the quantity of the order
	Given user clicks on Order button
	When user provides the mandatory fields for the order
	| Product   | Quantity   | CustomerName   | Street   | City   | State   | Zip   | CardType   | CardNo   | ExpDate   |
	| <product> | <quantity> | <customername> | <street> | <city> | <State> | <Zip> | <cardtype> | <CardNo> | <expdate> |
	And user clicks on the process button
	Then verify the order is placed
	And user clicks on view all orders
	And clicks on the edit button for the newly created order
	And update the quantity of the order to "3"
	Then verify the order quantity is updated
	When user clicks on the logout button
	Then verify the user is successfully logged out

	Examples: 
	| product     | quantity | customername | street         | city      | State | Zip  | cardtype | CardNo           | expdate |
	| MyMoney     | 2        | Namresh      | Tulip Crescent | Melbourne | Vic   | 3155 | Visa     | 4532411343848790 | 09/22   |

@testcomplete
Scenario Outline: Delete the order created
	Given user clicks on Order button
	When user provides the mandatory fields for the order
	| Product   | Quantity   | CustomerName   | Street   | City   | State   | Zip   | CardType   | CardNo   | ExpDate   |
	| <product> | <quantity> | <customername> | <street> | <city> | <State> | <Zip> | <cardtype> | <CardNo> | <expdate> |
	And user clicks on the process button
	Then verify the order is placed
	And user clicks on view all orders
	And clicks on the checkbox  for the newly created order
	And clicks on the delete button
	Then verify the order is deleted
	When user clicks on the logout button
	Then verify the user is successfully logged out

	Examples: 
	| product     | quantity | customername | street         | city      | State | Zip  | cardtype | CardNo           | expdate |
	| MyMoney     | 2        | Namresh      | Tulip Crescent | Melbourne | Vic   | 3155 | Visa     | 4532411343848790 | 09/22   |