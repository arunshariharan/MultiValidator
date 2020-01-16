# Sample Validation Project

## Question
Design a validation mechanism where we can easily add/remove/edit functionalities. Keep in mind which design pattern will be used and these principles SOLID, DRY and able to do unit tests when you develop the application.

#### Example:
when creating call connect service for a dealer from DST UI, we need to choose phone number, ring timeout, business hours, etc these values need to be validated before saving to database. Our goal is to create a solid validation mechanism that can take different validators with different models and ease to add/modify/remove.

## My solution
* Use Chain of Responsibility pattern to easily register / deregister validations for each type of handler
* Each validator can be unit tested easily
* Each validator can be injected and retreived using asp net core's dependency injection