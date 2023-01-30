module Tests.Fixtures.Edits

let createEditResponse () =
    """
    {
        "object": "edit",
        "created": 1675094843,
        "choices": [
            {
                "text": "What day of the week is it?\n",
                "index": 0
            }
        ],
        "usage": {
            "prompt_tokens": 25,
            "completion_tokens": 28,
            "total_tokens": 53
        }
    }
    """
