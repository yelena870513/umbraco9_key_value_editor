# Umbraco 9 Key Pair Editor
Editor simple de tablas para umbraco 9, con lista llave - valor

### Umbraco 9 Key Value List

The Key Value Editor package allows editors to create key value pair lists within instances of their document types. The editor can add, edit and delete pairs. The current version of this package is only compatible with version 9 of Umbraco.

## Set Up

Create a new data type using the Umbraco 9 Key Value List property editor. Add a new property to a document type using the new data type you have just created. Once you have created your new property, you should be able to add a list of key value pairs on any instances of your document type where the new data type exists.

## Converter

When using a property value on a template, add the following code to create a strongly type version of the key value editor property value.

    @{
        Dictionary<string, string> keyValuePairs = CurrentPage.GetPropertyValue<Dictionary<string, string>>("alias");
    }

Once converted, you will be able to choose single items and loop through each. For example:

    @{
        // Find a single key value pair based on key
        var single = keyValuePairs.SingleOrDefault(k => k.Key.Equals("local"));

        // Loop through each pair
        foreach (var pair in keyValuePairs)
        {
            @pair.Key;
            @pair.Value;
        }
    }
#Inspired on
[RB](https://bitbucket.org/rbdigital/umbraco-keyvalue-editor)
## Contributing

To raise a new bug, create an [issue](https://github.com/yelena870513/umbraco9_key_value_editor/issues) on the Git Hub repository. To fix a bug or add new features or providers, fork the repository and send a [pull request](https://bitbucket.org/rbdigital/umbraco-keyvalue-editor/pull-requests) with your changes. Feel free to add ideas to the repository's [issues](https://github.com/yelena870513/umbraco9_key_value_editor/issues) list if you would to discuss anything related to the package.
