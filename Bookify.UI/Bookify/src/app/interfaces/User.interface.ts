export interface User{
    id: string,
    firstName: string,
    lastName: string,
    age: number,
    email: string,
    password: string,
    confirmPassword: string,
    addressLine1: string,
    addressLine2: string,
    state: string,
    city: string,
    country: string,
    zipCode: string,
    cardOwner: string,
    creditCardNumber: string,
    cvv: string,
    expiration: string | undefined
}