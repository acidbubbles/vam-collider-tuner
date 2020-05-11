using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

using Object = UnityEngine.Object;

public class RigidbodyModel : ColliderContainerModelBase<Rigidbody>, IModel
{
    private readonly bool _initialEnabled;

    private List<UIDynamic> _controls;

    public List<Group> Groups { get; set; }
    public List<ColliderModel> Colliders { get; set; } = new List<ColliderModel>();

    public RigidbodyModel(MVRScript script, Rigidbody rigidbody)
        : base(script, rigidbody, $"[rb] {Simplify(rigidbody.name)}")
    {
        _initialEnabled = rigidbody.detectCollisions;
    }

    public override IEnumerable<ColliderModel> GetColliders() => Colliders;

    protected override void CreateControls()
    {
        DestroyControls();

        var controls = new List<UIDynamic>();

        var resetUi = Script.CreateButton("Reset Rigidbody", true);
        resetUi.button.onClick.AddListener(ResetToInitial);

        var enabledToggleJsf = new JSONStorableBool("enabled", Component.detectCollisions, value => { Component.detectCollisions = value; });
        var enabledToggle = Script.CreateToggle(enabledToggleJsf, true);
        enabledToggle.label = "Detect Collisions";

        controls.Add(resetUi);
        controls.Add(enabledToggle);

        _controls = controls;
    }

    protected override void DestroyControls()
    {
        if (_controls == null)
            return;

        foreach (var control in _controls)
            Object.Destroy(control.gameObject);

        _controls.Clear();
    }

    protected override void DoLoadJson(JSONClass jsonClass)
    {
        Component.detectCollisions = jsonClass["detectCollisions"].AsBool;
    }

    protected override JSONClass DoGetJson()
    {
        var jsonClass = new JSONClass();
        jsonClass["detectCollisions"].AsBool = Component.detectCollisions;
        return jsonClass;
    }

    public void ResetToInitial()
    {
        DoResetToInitial();

        if (Selected)
        {
            DestroyControls();
            CreateControls();
        }
    }

    protected void DoResetToInitial()
    {
        Component.detectCollisions = _initialEnabled;
    }

    protected bool DeviatesFromInitial() => Component.detectCollisions != _initialEnabled;
}
