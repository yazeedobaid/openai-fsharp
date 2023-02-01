module Tests.Fixtures.Files

let listFilesResponse () =
    """
    {
        "object": "list",
        "data": [
            {
                "object": "file",
                "id": "file-Lpe0n5tOHtoG6OVVbk5d4iXA",
                "purpose": "fine-tune",
                "filename": "sample.txt",
                "bytes": 204,
                "created_at": 1675262376,
                "status": "processed",
                "status_details": null
            },
            {
                "object": "file",
                "id": "file-qtUwySute1Zf2yT6mWIGTCwq",
                "purpose": "fine-tune",
                "filename": "MyFile.jsonl.txt",
                "bytes": 204,
                "created_at": 1675262252,
                "status": "processed",
                "status_details": null
            }
        ]
    }
    """

let uploadFileResponse () =
    """
    {
        "object": "file",
        "id": "file-Lpe0n5tOHtoG6OVVbk5d4iXA",
        "purpose": "fine-tune",
        "filename": "Fixtures/sample-json.txt",
        "bytes": 204,
        "created_at": 1675262376,
        "status": "uploaded",
        "status_details": null
    }
    """

let deleteFileResponse () =
    """
    {
        "object": "file",
        "id": "file-z9t9NWFy7hXP1H2w0wtsz8ei",
        "deleted": true
    }
    """

let retrieveFileResponse () =
    """
    {
        "object": "file",
        "id": "file-qtUwySute1Zf2yT6mWIGTCwq",
        "purpose": "fine-tune",
        "filename": "MyFile.jsonl.txt",
        "bytes": 204,
        "created_at": 1675262252,
        "status": "processed",
        "status_details": null
    }
    """
