# HttpPatch With JsonPatch

This article explains how to handle JSON Patch requests in an ASP.NET Core web API.

# Purpose of HttpPatch:

HttpPatch helps us to do partial updates to REST API resources, So that fewer data will transfer over wire. 

Assume you have a complex object with 100 fields, Out of 100 fields you just need to update 2 fields. 

# What will you do?
Will you pass all fields in request? or only two fields that you want to update?

Obversely I will pass fields that want to update. So that fewer data will transfer over the network.

We can achieve this feature with JSON Patch.  

# What is JSON Patch?

JSON Patch is a format for describing changes to a JSON document. It can be used to avoid sending a whole document when only a part has changed. 
When used in combination with the HTTP PATCH method, it allows partial updates for HTTP APIs in a standards-compliant way.

## Package installation

To enable JSON Patch support in your app, complete the following steps:

1. Install the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) NuGet package.

    ```csharp
    services
        .AddControllers()
        .AddNewtonsoftJson();
    ```

The PUT and PATCH methods are used to update an existing resource. The difference between them is that PUT replaces the entire resource, while PATCH specifies only the changes.

While requesting the `HttpPatch` method. We need to pass three values (op, path, value)


* The `op` property indicates the type of operation.
* The `path` property indicates the element to update.
* The `value` property provides the new value.

## Resource example


```json
[
    {
        "empUId": 10,
        "dateofBirth": "1991-10-12T00:00:00",
        "employeeName": {
            "empId": 1,
            "firstName": "Manam",
            "lastName": "Navaneeswar",
            "middleName": null,
            "empUId": 10
        },
        "employeeEmail": {
            "emailId": 1,
            "email": "eswarbe2009@gmail.com",
            "emailType": "Personal",
            "empUId": 10
        },
        "employeePhone": {
            "phoneId": 1,
            "phoneNumber": "9966661711",
            "phoneType": "Home",
            "empUId": 10
        }
    }
]
```

## JSON patch example

```json
[
    {
        "op": "add",
        "path": "/dateofBirth",
        "value": "1991-10-13T00:00:00"
    },
    {
        "op":"add",
        "path": "/employeeEmail",
        "value": {
            "emailId": 1,
            "email": "eswarbe2009@out.com",
            "emailType": "Personal",
            "empUId": 10
        }
    }
]
```

### Resource after patch

Here's the resource after applying the preceding JSON Patch document:

```json
{
    "empUId": 10,
    "dateofBirth": "1991-10-13T00:00:00",
    "employeeName": {
        "empId": 1,
        "firstName": "Manam",
        "lastName": "Navaneeswar",
        "middleName": null,
        "empUId": 10
    },
    "employeeEmail": {
        "emailId": 1,
        "email": "eswarbe2009@out.com",
        "emailType": "Personal",
        "empUId": 10
    },
    "employeePhone": {
        "phoneId": 1,
        "phoneNumber": "9966661711",
        "phoneType": "Home",
        "empUId": 10
    }
}
```

The changes made by applying a JSON Patch document to a resource are atomic. If any operation in the list fails, no operation in the list is applied.

## Path syntax

The [path](https://tools.ietf.org/html/rfc6901) property of an operation object has slashes between levels. For example, `"/address/zipCode"`.

Zero-based indexes are used to specify array elements. The first element of the `addresses` array would be at `/addresses/0`. To `add` to the end of an array, use a hyphen (`-`) rather than an index number: `/addresses/-`.

### Operations

The following table shows supported operations as defined in the [JSON Patch specification](https://tools.ietf.org/html/rfc6902):

|Operation  | Notes |
|-----------|--------------------------------|
| `add`     | Add a property or array element. For existing property: set value.|
| `remove`  | Remove a property or array element. |
| `replace` | Same as `remove` followed by `add` at same location. |
| `move`    | Same as `remove` from source followed by `add` to destination using value from source. |
| `copy`    | Same as `add` to destination using value from source. |
| `test`    | Return success status code if value at `path` = provided `value`.|
