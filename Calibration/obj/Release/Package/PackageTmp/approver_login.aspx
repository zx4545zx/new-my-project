<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="approver_login.aspx.cs" Inherits="Calibration.approver_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:UpdatePanel ID="updatepnl" runat="server">
    <ContentTemplate>

      <style>
        .bbody {
          display: flex;
          align-items: center;
          padding-top: 40px;
          padding-bottom: 40px;
          height: 100%;
        }

        .form-signin {
          width: 100%;
          max-width: 330px;
          padding: 15px;
          margin: auto;
        }

          .form-signin .checkbox {
            font-weight: 400;
          }

          .form-signin .form-floating:focus-within {
            z-index: 2;
          }

          .form-signin input[type="email"] {
            margin-bottom: -1px;
            border-bottom-right-radius: 0;
            border-bottom-left-radius: 0;
          }

          .form-signin input[type="password"] {
            margin-bottom: 10px;
            border-top-left-radius: 0;
            border-top-right-radius: 0;
          }

        .bd-placeholder-img {
          font-size: 1.125rem;
          text-anchor: middle;
          -webkit-user-select: none;
          -moz-user-select: none;
          user-select: none;
        }

        @media (min-width: 768px) {
          .bd-placeholder-img-lg {
            font-size: 3.5rem;
          }
        }
      </style>

      <div class="bbody">


        <main class="form-signin">
          <div>
            <asp:Panel ID="Panel1" DefaultButton="Submit" runat="server">
              <h1 class="h3 mb-3 fw-normal text-center">Please sign in</h1>

              <div class="form-floating">
                <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com" runat="server">
                <label for="floatingInput">Email address</label>
              </div>
              <div class="form-floating">
                <input type="password" class="form-control" id="floatingPassword" placeholder="Password" runat="server">
                <label for="floatingPassword">Password</label>
              </div>

              <div class="checkbox mb-3">
                <label>
                  <input type="checkbox" value="remember-me">
                  Remember me
                </label>
              </div>
              <asp:Button ID="Submit" CssClass="w-100 btn btn-lg btn-primary" runat="server" Text="Sign in" CausesValidation="false" OnClick="Button2_Click" />
            </asp:Panel>
          </div>
        </main>


      </div>



    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
