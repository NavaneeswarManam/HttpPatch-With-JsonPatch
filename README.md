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

