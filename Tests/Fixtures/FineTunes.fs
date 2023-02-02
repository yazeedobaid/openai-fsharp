module Tests.Fixtures.FineTunes


let createFineTuneResponse () =
    """
    {
        "object": "fine-tune",
        "id": "ft-BFEIdtwzxz4UsnVcdQRInPKI",
        "hyperparams": {
            "n_epochs": 4,
            "batch_size": null,
            "prompt_loss_weight": 0.01,
            "learning_rate_multiplier": null
        },
        "organization_id": "org-HqJyr2hpU71AGbpla5U79HFg",
        "model": "curie",
        "training_files": [
            {
                "object": "file",
                "id": "file-Lpe0n5tOHtoG6OVVbk5d4iXA",
                "purpose": "fine-tune",
                "filename": "sample.txt",
                "bytes": 204,
                "created_at": 1675262376,
                "status": "processed",
                "status_details": null
            }
        ],
        "validation_files": [],
        "result_files": [],
        "created_at": 1675332768,
        "updated_at": 1675332768,
        "status": "pending",
        "fine_tuned_model": null,
        "events": [
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Created fine-tune: ft-BFEIdtwzxz4UsnVcdQRInPKI",
                "created_at": 1675332768
            }
        ]
    }
    """

let listFineTunesResponse () =
    """
    {
        "object": "list",
        "data": [
            {
                "object": "fine-tune",
                "id": "ft-BFEIdtwzxz4UsnVcdQRInPKI",
                "hyperparams": {
                    "n_epochs": 4,
                    "batch_size": 1,
                    "prompt_loss_weight": 0.01,
                    "learning_rate_multiplier": 0.1
                },
                "organization_id": "org-HqJyr2hpU71AGbpla5U79HFg",
                "model": "curie",
                "training_files": [
                    {
                        "object": "file",
                        "id": "file-Lpe0n5tOHtoG6OVVbk5d4iXA",
                        "purpose": "fine-tune",
                        "filename": "sample.txt",
                        "bytes": 204,
                        "created_at": 1675262376,
                        "status": "processed",
                        "status_details": null
                    }
                ],
                "validation_files": [],
                "result_files": [],
                "created_at": 1675332768,
                "updated_at": 1675332916,
                "status": "running",
                "fine_tuned_model": "curie:ft-personal-2023-02-02-10-15-10"
            }
        ]
    }
    """

let retrieveFineTuneResponse () =
    """
    {
        "object": "fine-tune",
        "id": "ft-BFEIdtwzxz4UsnVcdQRInPKI",
        "hyperparams": {
            "n_epochs": 4,
            "batch_size": 1,
            "prompt_loss_weight": 0.01,
            "learning_rate_multiplier": 0.1
        },
        "organization_id": "org-HqJyr2hpU71AGbpla5U79HFg",
        "model": "curie",
        "training_files": [
            {
                "object": "file",
                "id": "file-Lpe0n5tOHtoG6OVVbk5d4iXA",
                "purpose": "fine-tune",
                "filename": "sample.txt",
                "bytes": 204,
                "created_at": 1675262376,
                "status": "processed",
                "status_details": null
            }
        ],
        "validation_files": [],
        "result_files": [
            {
                "object": "file",
                "id": "file-2fFRl7qGRCMZYNfCjYC9WMvU",
                "purpose": "fine-tune-results",
                "filename": "compiled_results.csv",
                "bytes": 633,
                "created_at": 1675332921,
                "status": "processed",
                "status_details": null
            }
        ],
        "created_at": 1675332768,
        "updated_at": 1675332940,
        "status": "succeeded",
        "fine_tuned_model": "curie:ft-personal-2023-02-02-10-15-10",
        "events": [
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Created fine-tune: ft-BFEIdtwzxz4UsnVcdQRInPKI",
                "created_at": 1675332768
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune costs $0.00",
                "created_at": 1675332834
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune enqueued. Queue number: 0",
                "created_at": 1675332834
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune started",
                "created_at": 1675332839
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 1/4",
                "created_at": 1675332885
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 2/4",
                "created_at": 1675332886
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 3/4",
                "created_at": 1675332887
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 4/4",
                "created_at": 1675332888
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Uploaded model: curie:ft-personal-2023-02-02-10-15-10",
                "created_at": 1675332916
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Uploaded result file: file-2fFRl7qGRCMZYNfCjYC9WMvU",
                "created_at": 1675332939
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune succeeded",
                "created_at": 1675332939
            }
        ]
    }
    """

let cancelFineTuneResponse () =
    """
    {
        "object": "fine-tune",
        "id": "ft-BFEIdtwzxz4UsnVcdQRInPKI",
        "hyperparams": {
            "n_epochs": 4,
            "batch_size": 1,
            "prompt_loss_weight": 0.01,
            "learning_rate_multiplier": 0.1
        },
        "organization_id": "org-HqJyr2hpU71AGbpla5U79HFg",
        "model": "curie",
        "training_files": [
            {
                "object": "file",
                "id": "file-Lpe0n5tOHtoG6OVVbk5d4iXA",
                "purpose": "fine-tune",
                "filename": "sample.txt",
                "bytes": 204,
                "created_at": 1675262376,
                "status": "processed",
                "status_details": null
            }
        ],
        "validation_files": [],
        "result_files": [
            {
                "object": "file",
                "id": "file-2fFRl7qGRCMZYNfCjYC9WMvU",
                "purpose": "fine-tune-results",
                "filename": "compiled_results.csv",
                "bytes": 633,
                "created_at": 1675332921,
                "status": "processed",
                "status_details": null
            }
        ],
        "created_at": 1675332768,
        "updated_at": 1675332940,
        "status": "cancelled",
        "fine_tuned_model": "curie:ft-personal-2023-02-02-10-15-10",
        "events": [
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Created fine-tune: ft-BFEIdtwzxz4UsnVcdQRInPKI",
                "created_at": 1675332768
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune costs $0.00",
                "created_at": 1675332834
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune enqueued. Queue number: 0",
                "created_at": 1675332834
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune started",
                "created_at": 1675332839
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 1/4",
                "created_at": 1675332885
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 2/4",
                "created_at": 1675332886
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 3/4",
                "created_at": 1675332887
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 4/4",
                "created_at": 1675332888
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Uploaded model: curie:ft-personal-2023-02-02-10-15-10",
                "created_at": 1675332916
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Uploaded result file: file-2fFRl7qGRCMZYNfCjYC9WMvU",
                "created_at": 1675332939
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune succeeded",
                "created_at": 1675332939
            }
        ]
    }
    """

let listFineTuneEventsResponse () =
    """
    {
        "object": "list",
        "data": [
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Created fine-tune: ft-BFEIdtwzxz4UsnVcdQRInPKI",
                "created_at": 1675332768
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune costs $0.00",
                "created_at": 1675332834
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune enqueued. Queue number: 0",
                "created_at": 1675332834
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune started",
                "created_at": 1675332839
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 1/4",
                "created_at": 1675332885
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 2/4",
                "created_at": 1675332886
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 3/4",
                "created_at": 1675332887
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Completed epoch 4/4",
                "created_at": 1675332888
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Uploaded model: curie:ft-personal-2023-02-02-10-15-10",
                "created_at": 1675332916
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Uploaded result file: file-2fFRl7qGRCMZYNfCjYC9WMvU",
                "created_at": 1675332939
            },
            {
                "object": "fine-tune-event",
                "level": "info",
                "message": "Fine-tune succeeded",
                "created_at": 1675332939
            }
        ]
    }
    """
