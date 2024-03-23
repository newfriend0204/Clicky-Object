using UnityEngine;
using UnityEngine.Purchasing; // Unity IAP ���ӽ����̽� �߰�

public class CheckRemoveAd : MonoBehaviour {
    private static IStoreController m_StoreController; // �ξ� ���Ÿ� ���� ����� ��Ʈ�ѷ� ����

    private string removeAdProductId = "remove_ad"; // ���� ���� ��ǰ�� ID
    private GameManager gameManager;

    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (m_StoreController == null) // �ξ� ���� �ý����� �ʱ�ȭ���� �ʾҴٸ�
        {
            InitializePurchasing(); // �ξ� ���� �ý��� �ʱ�ȭ
        }
    }

    void InitializePurchasing() {
        if (IsInitialized()) // �̹� �ʱ�ȭ�Ǿ����� Ȯ��
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct(removeAdProductId, ProductType.NonConsumable); // ���� ���� ��ǰ �߰�
        //UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized() {
        return m_StoreController != null;
    }

    //public void OnInitialized(IStoreController controller, IExtensionProvider extensions) {
    //    m_StoreController = controller;
    //}

    //public void OnInitializeFailed(InitializationFailureReason error) {
    //    Debug.Log("Unity IAP �ʱ�ȭ ����: " + error);
    //}

    //public void OnInitializeFailed(InitializationFailureReason error, string message) {
    //    Debug.Log("Unity IAP �ʱ�ȭ ����: " + error + ", �޽���: " + message);
    //}


    //public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) {
    //    return PurchaseProcessingResult.Complete;
    //}

    //public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason) {
    //    Debug.Log(string.Format("���� ����: {0}, ����: {1}", product.definition.id, failureReason));
    //}

    void CheckPurchase() {
        Product product = m_StoreController.products.WithID(removeAdProductId);

        if (product != null && product.hasReceipt) {
            gameManager.ad = 1;
            Debug.Log("���� ���� ��ǰ ���� Ȯ�ε�. ���� ǥ������ �ʽ��ϴ�.");
        } else {
            // ��ǰ�� �������� �ʾҴٸ� ���⿡ ���� ǥ���ϴ� ������ �����ϼ���.
            Debug.Log("���� ���� ��ǰ ���� Ȯ�ε��� ����. ���� ǥ���մϴ�.");
        }
    }

    void Update() {
        if (IsInitialized()) // Unity IAP�� �ʱ�ȭ�Ǿ��ٸ�
        {
            CheckPurchase(); // ���� ���� Ȯ��
        }
    }
}